using CardShop.Models.Domain;
using CardShop.Models.ViewModels;
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

        public AccountController(UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
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
                return View(model);

            User newUser = new()
            {
                UserName = model.Email,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if(result.Succeeded)
            {
                await _signInManager.PasswordSignInAsync(newUser, model.Password, isPersistent: false,
                    lockoutOnFailure: false);
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
