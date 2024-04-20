﻿using CardShop.Areas.Admin.Models.ViewModels;
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
        public async Task<IActionResult> Index(string search = "")
        {
            SearchVM<User> model = new SearchVM<User>()
            {
                Search = search,
                Items = _userManager.Users
            }; 

            if(search != String.Empty)
                model.Items = model.Items.Where(u => u.LastName.ContainsNoCase(search) 
                    || u.FirstName.ContainsNoCase(search)).ToList();
            
            return View(model);
        }
    }
}
