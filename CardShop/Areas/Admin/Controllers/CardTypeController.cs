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
    public class CardTypeController : Controller
    {
        private Repository<CardType> cardTypeDb { get; set; }

        public CardTypeController(ApplicationDbContext ctx)
        {
            cardTypeDb = new Repository<CardType>(ctx);
        }

        [Route("{area}/cardtypes")]
        public IActionResult Index(string searchString = "")
        {
            SearchVM<CardType> model = new SearchVM<CardType>()
            {
                Search = searchString,
                Items = cardTypeDb.List(new QueryOptions<CardType>())
            };

            if (searchString != String.Empty)
                model.Items = model.Items.Where(c => c.Name.ContainsNoCase(searchString) ||
                    c.Name.ContainsNoCase(searchString)).ToList();

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            CardType? type = cardTypeDb.Get(id);

            if (type == null)
                return RedirectToAction("Index");

            ManageVM<CardType> vm = new()
            {
                Action = "Edit",
                Item = type
            };

            return View("Manage", vm);
        }

        public IActionResult Add()
        {
            ManageVM<CardType> vm = new()
            {
                Action = "Add",
                Item = new CardType()
            };

            return View("Manage", vm);
        }

        public IActionResult Manage(ManageVM<CardType> model)
        {
            if (ModelState.IsValid)
            {
                if(model.Item.TypeId == 0)
                    cardTypeDb.Add(model.Item);
                else
                    cardTypeDb.Update(model.Item);
                cardTypeDb.Save();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
