using CardShop.Data;
using CardShop.Data.Repository;
using CardShop.Models.Domain;
using CardShop.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace CardShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly Repository<CardPurchase> _purchaseDb;

        public AccountController(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager, ApplicationDbContext ctx)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _purchaseDb = new Repository<CardPurchase>(ctx);
        }

        public IActionResult Login(string returnUrl)
        {
            LoginVM model = new()
            {
                ReturnURL = returnUrl
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if(!ModelState.IsValid)
                return View(model);

            User user = new()
            {
                UserName = model.Email,
                Email = model.Email,
            };

            var result = await _signInManager.PasswordSignInAsync(user.UserName, 
                model.Password, isPersistent: model.IsRemembered, lockoutOnFailure:false);

            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(model.ReturnURL) &&
                    Url.IsLocalUrl(model.ReturnURL))
                    return Redirect(model.ReturnURL);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid Email or Password");
            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
                

            User newUser = new()
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if(result.Succeeded)
            {
                await _signInManager.PasswordSignInAsync(newUser, model.Password, isPersistent: false,
                    lockoutOnFailure: false);
                return RedirectToAction("Index", "Home");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Manager()
        {
            return View();
        }

        [Authorize]
        public IActionResult ChangePassword()
        {
            ChangePasswordVM vm = new ChangePasswordVM() 
            {
                Email = User.Identity.Name
            };
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            User? user = await _userManager.FindByNameAsync(model.Email);

            var result = await _userManager.ChangePasswordAsync(user,
                model.OldPassword, model.NewPassword);

            if (result.Succeeded)
                return RedirectToAction("Manager");
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        [Authorize]
        public IActionResult Purchases()
        {
            IEnumerable<CardPurchase> purchases = _purchaseDb.List(new QueryOptions<CardPurchase>
            {
                Includes = "Purchase, TradingCard",
                Where = p => p.Purchase.UserId == _userManager.GetUserId(User)
            });

            return View(purchases);
        }

        [Authorize]
        public IActionResult AccessDenied() => View();
    }
}
