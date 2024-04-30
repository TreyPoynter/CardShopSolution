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
    public class ManufacturerController : Controller
    {
        private Repository<Manufacturer> manufacturerDb { get; set; }

        public ManufacturerController(ApplicationDbContext ctx)
        {
            manufacturerDb = new Repository<Manufacturer>(ctx);
        }

        [Route("{area}/manufacturers")]
        public IActionResult Index(string searchString = "")
        {
            SearchVM<Manufacturer> model = new SearchVM<Manufacturer>()
            {
                Search = searchString,
                Items = manufacturerDb.List(new QueryOptions<Manufacturer>())
            };

            if (searchString != String.Empty)
                model.Items = model.Items.Where(c => c.Name.ContainsNoCase(searchString) ||
                    c.Name.ContainsNoCase(searchString)).ToList();

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            Manufacturer? manufacturer = manufacturerDb.Get(id);

            if (manufacturer == null)
                return RedirectToAction("Index");

            ManageVM<Manufacturer> vm = new()
            {
                Action = "Edit",
                Item = manufacturer
            };

            return View("Manage", vm);
        }

        public IActionResult Add()
        {
            ManageVM<Manufacturer> vm = new()
            {
                Action = "Add",
                Item = new Manufacturer()
            };

            return View("Manage", vm);
        }

        public IActionResult Manage(ManageVM<Manufacturer> model)
        {
            if (ModelState.IsValid)
            {
                if(model.Item.ManufacturerId == 0)
                    manufacturerDb.Add(model.Item);
                else
                    manufacturerDb.Update(model.Item);
                manufacturerDb.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
