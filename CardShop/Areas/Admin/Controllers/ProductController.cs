using CardShop.Areas.Admin.Models.ViewModels;
using CardShop.Data;
using CardShop.Data.Repository;
using CardShop.Models;
using CardShop.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using System.Reflection;

namespace CardShop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ProductController : Controller
    {
        private IWebHostEnvironment webHostEnvironment;
        private Repository<TradingCard> cardDb {  get; set; }
        private Repository<Sport> sportDb {  get; set; }
        private Repository<Manufacturer> manufacturerDb {  get; set; }
        private Repository<Quality> qualityDb {  get; set; }
        private Repository<CardType> typeDb {  get; set; }

        public ProductController(ApplicationDbContext ctx, IWebHostEnvironment webHostEnv)
        {
            cardDb = new Repository<TradingCard>(ctx);
            sportDb = new Repository<Sport>(ctx);
            manufacturerDb = new Repository<Manufacturer>(ctx);
            qualityDb = new Repository<Quality>(ctx);
            typeDb = new Repository<CardType>(ctx);
            webHostEnvironment = webHostEnv;

        }

        [Route("{area}/Products")]
        public IActionResult Index(string search = "")
        {
            SearchVM<TradingCard> model = new SearchVM<TradingCard>()
            {
                Search = search,
                Items = cardDb.List(new QueryOptions<TradingCard>()
                {
                    Includes = "Type, Quality, Manufacturer, Sport"
                })
            };

            if(search != String.Empty)
                model.Items = model.Items.Where(c => c.Sport.Name.ContainsNoCase(search) ||
                    c.Player.ContainsNoCase(search)).ToList();

            return View(model);
        }
        [Route("{area}/Product/Add")]
        public IActionResult Add()
        {
            CardCreationVM newCard = new CardCreationVM() 
            {
                Card = new TradingCard(),
                Sports = sportDb.List(new QueryOptions<Sport>()),
                Manufacturers = manufacturerDb.List(new QueryOptions<Manufacturer>()),
                Qualities = qualityDb.List(new QueryOptions<Quality>()),
                Types = typeDb.List(new QueryOptions<CardType>())
            };

            return View(newCard);
        }
        [Route("{area}/Product/Add")]
        [HttpPost]
        public IActionResult Add(CardCreationVM cardVM)
        {
            if (ModelState.IsValid)
            {
                string uploadDir = Path.Combine(webHostEnvironment.WebRootPath, "images");
                string fileName = cardVM.Image.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    cardVM.Image.CopyTo(fileStream);
                }

                if (cardVM.Card.Description == null)
                    cardVM.Card.Description = String.Empty;

                var options = new ProductCreateOptions
                {
                    Name = cardVM.Card.Player,
                    DefaultPriceData = new ProductDefaultPriceDataOptions
                    {
                        UnitAmountDecimal = cardVM.Card.Price,
                        Currency = "USD"
                    }
                };

                TradingCard card = new TradingCard()
                {
                    Player = cardVM.Card.Player,
                    Description = cardVM.Card.Description,
                    Price = cardVM.Card.Price,
                    Year = cardVM.Card.Year,
                    Number = cardVM.Card.Number,
                    TypeId = cardVM.Card.TypeId,
                    QualityId = cardVM.Card.QualityId,
                    ManufactuererId = cardVM.Card.ManufactuererId,
                    SportId = cardVM.Card.SportId,
                    ImageName = fileName
                };
                cardDb.Add(card);
                cardDb.Save();
                return RedirectToAction("Index");
            }
            cardVM.Sports = sportDb.List(new QueryOptions<Sport>());
            cardVM.Manufacturers = manufacturerDb.List(new QueryOptions<Manufacturer>());
            cardVM.Qualities = qualityDb.List(new QueryOptions<Quality>());
            cardVM.Types = typeDb.List(new QueryOptions<CardType>());
            return View(cardVM);
        }
    }
}
