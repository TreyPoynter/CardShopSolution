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
    public class SportController : Controller
    {
        private Repository<Sport> sportDb { get; set; }

        public SportController(ApplicationDbContext ctx)
        {
            sportDb = new Repository<Sport>(ctx);
        }

        [Route("{area}/Sports")]
        public IActionResult Index(string searchString = "")
        {
            SearchVM<Sport> model = new SearchVM<Sport>()
            {
                Search = searchString,
                Items = sportDb.List(new QueryOptions<Sport>())
            };

            if (searchString != String.Empty)
                model.Items = model.Items.Where(c => c.Name.ContainsNoCase(searchString) ||
                    c.Name.ContainsNoCase(searchString)).ToList();

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            Sport? sport = sportDb.Get(id);

            if (sport == null)
                return RedirectToAction("Index");

            ManageVM<Sport> vm = new()
            {
                Action = "Edit",
                Item = sport
            };

            return View("Manage", vm);
        }

        public IActionResult Add()
        {
            ManageVM<Sport> vm = new()
            {
                Action = "Add",
                Item = new Sport()
            };

            return View("Manage", vm);
        }

        public IActionResult Manage(ManageVM<Sport> model)
        {
            if (ModelState.IsValid)
            {
                if(model.Item.SportId == 0)
                    sportDb.Add(model.Item);
                else
                    sportDb.Update(model.Item);
                sportDb.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
