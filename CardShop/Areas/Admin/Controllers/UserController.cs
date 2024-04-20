using CardShop.Models.Domain;
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
        public async Task<IActionResult> Index(string search = "")
        {
            List<User> users = await _userManager.Users.ToListAsync();

            if(search != String.Empty)
                users = users.Where(u => u.FirstName.Contains(search) || u.LastName.Contains(search))
                    .ToList();

            return View(users);
        }
    }
}
