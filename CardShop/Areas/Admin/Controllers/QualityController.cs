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
    public class QualityController : Controller
    {
        private Repository<Quality> qualityDb { get; set; }

        public QualityController(ApplicationDbContext ctx)
        {
            qualityDb = new Repository<Quality>(ctx);
        }

        [Route("{area}/Qualities")]
        public IActionResult Index(string searchString = "")
        {
            SearchVM<Quality> model = new SearchVM<Quality>()
            {
                Search = searchString,
                Items = qualityDb.List(new QueryOptions<Quality>())
            };

            if (searchString != String.Empty)
                model.Items = model.Items.Where(c => c.Type.ContainsNoCase(searchString) ||
                    c.Type.ContainsNoCase(searchString)).ToList();

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            Quality? quality = qualityDb.Get(id);

            if (quality == null)
                return RedirectToAction("Index");

            ManageVM<Quality> vm = new()
            {
                Action = "Edit",
                Item = quality
            };

            return View("Manage", vm);
        }

        public IActionResult Add()
        {
            ManageVM<Quality> vm = new()
            {
                Action = "Add",
                Item = new Quality()
            };

            return View("Manage", vm);
        }

        public IActionResult Manage(ManageVM<Quality> model)
        {
            if (ModelState.IsValid)
            {
                if(model.Item.QualityId == 0)
                    qualityDb.Add(model.Item);
                else
                    qualityDb.Update(model.Item);
                qualityDb.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
