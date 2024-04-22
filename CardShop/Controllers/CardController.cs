using CardShop.Data;
using CardShop.Data.Repository;
using CardShop.Models.Domain;
using CardShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CardShop.Controllers
{
    public class CardController : Controller
    {
        private readonly Repository<TradingCard> _cardDb;

        public CardController(ApplicationDbContext ctx)
        {
            _cardDb = new Repository<TradingCard>(ctx);
        }

        [Route("/Cards/{id?}")]
        public IActionResult Index(string id)
        {
            ViewBag.Id = id;
            CardCategoryVM cardsCategoryVM = new()
            {
                Category = id,
                Cards = _cardDb.List(new QueryOptions<TradingCard>()
                {
                    OrderBy = c => c.Player,
                    Where = c => c.Sport.Name == id,
                    Includes = "Type, Quality, Manufacturer, Sport"
                })
            };

            return View(cardsCategoryVM);
        }
    }
}
