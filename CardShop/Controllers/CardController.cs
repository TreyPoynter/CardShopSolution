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
                Category = id.Length > 3 ? id.Capitalize() : id.ToUpper(),
                Cards = _cardDb.List(new QueryOptions<TradingCard>()
                {
                    OrderBy = c => c.Player,
                    Where = c => c.Sport.Name == id && c.IsForSale,
                    Includes = "Types, Quality, Manufacturer, Sport, Team"
                })
            };

            return View(cardsCategoryVM);
        }

        [HttpGet]
        public IActionResult Search(string searchString)
        {
            CardCategoryVM cardsCategoryVM = new()
            {
                Category = searchString,
                Cards = _cardDb.List(new QueryOptions<TradingCard>()
                {
                    OrderBy = c => c.Player,
                    Where = c => c.IsForSale,
                    Includes = "Types, Quality, Manufacturer, Sport, Team",
                }),
                IsSearching = true
            };
            
            if (!String.IsNullOrWhiteSpace(searchString))
            {
                string[] searchTerms = searchString.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                cardsCategoryVM.Cards = cardsCategoryVM.Cards.Where(
                c => c.Player.ContainsNoCase(searchString) ||
                c.Description.ContainsNoCase(searchString) ||
                c.Team.Name.ContainsNoCase(searchString) ||
                c.Types.Count(t => searchTerms.Any(term => t.Name.ContainsNoCase(term))) > 0  ||
                c.Manufacturer.Name.ContainsNoCase(searchString) ||
                c.Sport.Name.ContainsNoCase(searchString));
            }else
            {
                cardsCategoryVM.IsSearching = false;
                cardsCategoryVM.Category = "All Cards";
            }
            
            return View("Index", cardsCategoryVM);
        }

        public IActionResult Details(int id)
        {
            TradingCard? card = _cardDb.Get(id);

            if (card == null)
                return View("NotFound");

            TradingCardDetailsVM detailsVM = new()
            {
                Card = card
            };

            return View(detailsVM);
        }
    }
}
