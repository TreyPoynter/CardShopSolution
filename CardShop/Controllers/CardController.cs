using CardShop.Data;
using CardShop.Data.Repository;
using CardShop.Models;
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
            CardCategoryVM cardsCategoryVM = new()
            {
                Category = id.Capitalize(),
                Cards = _cardDb.List(new QueryOptions<TradingCard>()
                {
                    OrderBy = c => c.Player,
                    Where = c => c.Sport.Name == id,
                    Includes = "Types, Quality, Manufacturer, Sport, Team"
                })
            };

            return View(cardsCategoryVM);
        }

        [HttpPost]
        public IActionResult Search(string search)
        {
            CardCategoryVM cardsCategoryVM = new()
            {
                Category = search,
                Cards = _cardDb.List(new QueryOptions<TradingCard>()
                {
                    OrderBy = c => c.Player,
                    Includes = "Types, Quality, Manufacturer, Sport, Team",
                }),
                IsSearching = true
            };
            if (!String.IsNullOrWhiteSpace(search))
            {
                cardsCategoryVM.Cards = _cardDb.Search(
                c => c.Player.ContainsNoCase(search) ||
                c.Description.ContainsNoCase(search) ||
                c.Team.Name.ContainsNoCase(search) ||
                c.Types.ToList().FindAll(t => t.Name.ContainsNoCase(search)).Count > 0  ||
                c.Manufacturer.Name.ContainsNoCase(search) ||
                c.Sport.Name.ContainsNoCase(search));
            }else
            {
                cardsCategoryVM.IsSearching = false;
                cardsCategoryVM.Category = "All Cards";
            }
            
            return View("Index", cardsCategoryVM);
        }
    }
}
