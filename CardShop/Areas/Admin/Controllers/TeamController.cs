using CardShop.Areas.Admin.Models.ViewModels;
using CardShop.Data;
using CardShop.Data.Repository;
using CardShop.Models;
using CardShop.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CardShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TeamController : Controller
    {
        private Repository<Team> teamDb { get; set; }

        public TeamController(ApplicationDbContext ctx)
        {
            teamDb = new Repository<Team>(ctx);
        }

        [Route("{area}/Teams")]
        public IActionResult Index(string searchString = "")
        {
            SearchVM<Team> model = new SearchVM<Team>()
            {
                Search = searchString,
                Items = teamDb.List(new QueryOptions<Team>())
            };

            if (searchString != String.Empty)
                model.Items = model.Items.Where(c => c.Name.ContainsNoCase(searchString) ||
                    c.Name.ContainsNoCase(searchString)).ToList();

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            Team? team = teamDb.Get(id);

            if (team == null)
                return RedirectToAction("Index");

            ManageVM<Team> vm = new()
            {
                Action = "Edit",
                Item = team
            };

            return View("Manage", vm);
        }

        public IActionResult Add()
        {
            ManageVM<Team> vm = new()
            {
                Action = "Add",
                Item = new Team()
            };

            return View("Manage", vm);
        }

        public IActionResult Manage(ManageVM<Team> model)
        {
            if (ModelState.IsValid)
            {
                if(model.Item.TeamId == 0)
                    teamDb.Add(model.Item);
                else
                    teamDb.Update(model.Item);
                teamDb.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
