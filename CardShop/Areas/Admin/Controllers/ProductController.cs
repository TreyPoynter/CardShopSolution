using CardShop.Areas.Admin.Models.ViewModels;
using CardShop.Data;
using CardShop.Data.Repository;
using CardShop.Models;
using CardShop.Models.Domain;
using CardShop.Models.ExtensionMethods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;

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
                var service = new ProductService();
                FileStreamExtensions.UploadImage(cardVM.Image, webHostEnvironment);

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
                    /*
                     * (When we upload let's change the filePath to the URL)
                     * Images = new List<string> { filePath }
                    */
                };

                var result = service.Create(options);
                TradingCard card = cardVM.Card;
                card.ProductId = result.Id;
                card.PriceId = result.DefaultPriceId;
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

        [Route("{area}/Product/Manage/{id?}")]
        public IActionResult Manage(int id)
        {
            TradingCard cardToEdit = cardDb.Get(id);
            string uploadDir = Path.Combine(webHostEnvironment.WebRootPath, "images");
            string filePath = Path.Combine(uploadDir, cardToEdit.ImageName);
            CardCreationVM cardVM = new CardCreationVM()
            {
                Card = cardToEdit,
                Sports = sportDb.List(new QueryOptions<Sport>()),
                Manufacturers = manufacturerDb.List(new QueryOptions<Manufacturer>()),
                Qualities = qualityDb.List(new QueryOptions<Quality>()),
                Types = typeDb.List(new QueryOptions<CardType>())
            };

            return View(cardVM);
        }
        [Route("{area}/Product/Manage/{id?}")]
        [HttpPost]
        public IActionResult Manage(CardCreationVM cardVM)
        {
            if (cardVM.Image != null)  // user chose a new image
            {
                FileStreamExtensions.UploadImage(cardVM.Image, webHostEnvironment);
                cardVM.Card.ImageName = cardVM.Image.FileName;
            }
            TradingCard updatedCard = cardVM.Card;

            if (updatedCard.Player != null &&
                updatedCard.Price != null && updatedCard.Price > 0 &&
                updatedCard.Year >= 1900 || updatedCard.Year <= DateTime.Now.Year &&
                updatedCard.Manufacturer != null &&
                updatedCard.Sport != null &&
                updatedCard.Type != null &&
                updatedCard.Quality != null)
            {
                var prodService = new ProductService();
                var priceService = new PriceService();
                
                if (cardVM.Card.Description == null)
                    cardVM.Card.Description = String.Empty;

                var product = prodService.Get(updatedCard.ProductId);
                Price priceToUpdate = priceService.Get(updatedCard.PriceId);

                if(priceToUpdate.UnitAmountDecimal != updatedCard.Price*100)
                {
                    var newPrice = priceService.Create(new PriceCreateOptions
                    {
                        UnitAmountDecimal = updatedCard.Price * 100,
                        Currency = "USD",
                        Product = updatedCard.ProductId
                    });
                    product.DefaultPrice = newPrice;
                }

                // Save the changes
                prodService.Update(updatedCard.ProductId, new ProductUpdateOptions
                {
                    Name = updatedCard.Player,
                    Description = updatedCard.Description,
                    Active = updatedCard.IsForSale,
                    DefaultPrice = priceToUpdate.Id,
                });
                updatedCard.PriceId = priceToUpdate.Id;
                cardDb.Update(updatedCard);
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
