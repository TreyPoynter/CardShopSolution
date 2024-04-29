using CardShop.Areas.Admin.Models.ViewModels;
using CardShop.Models.Domain;
using CardShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CardShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        [Route("{area}/Users")]
        public async Task<IActionResult> Index(string searchString = "")
        {
            SearchVM<User> model = new SearchVM<User>()
            {
                Search = searchString,
                Items = _userManager.Users
            }; 

            if(searchString != String.Empty)
                model.Items = model.Items.Where(u => u.LastName.ContainsNoCase(searchString) 
                    || u.FirstName.ContainsNoCase(searchString)).ToList();
            
            return View(model);
        }
    }
}
