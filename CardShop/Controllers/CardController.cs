using CardShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CardShop.Controllers
{
    public class CardController : Controller
    {
        [Route("/Cards/{id?}")]
        public IActionResult Index(string id)
        {
            ViewBag.Id = id;
            CardCategoryVM cardsCategoryVM = new()
            {
                Category = id
            };

            return View(cardsCategoryVM);
        }
    }
}
