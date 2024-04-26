using CardShop.Areas.Admin.Models.ViewModels;
using CardShop.Data;
using CardShop.Data.Repository;
using CardShop.Models;
using CardShop.Models.Domain;
using CardShop.Models.ExtensionMethods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Issuing;

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
        private Repository<Team> teamDb {  get; set; }

        public ProductController(ApplicationDbContext ctx, IWebHostEnvironment webHostEnv)
        {
            cardDb = new Repository<TradingCard>(ctx);
            sportDb = new Repository<Sport>(ctx);
            manufacturerDb = new Repository<Manufacturer>(ctx);
            qualityDb = new Repository<Quality>(ctx);
            typeDb = new Repository<CardType>(ctx);
            teamDb = new Repository<Team>(ctx);
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
                    Includes = "Quality, Manufacturer, Sport"
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
                Card = new TradingCard()
            };
            GetModelProperties(ref newCard);
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
                cardVM.Card.ImageName = cardVM.Image.FileName;

                if (cardVM.Card.Description == null)
                    cardVM.Card.Description = String.Empty;

                var options = new ProductCreateOptions
                {
                    Name = cardVM.Card.Player,
                    DefaultPriceData = new ProductDefaultPriceDataOptions
                    {
                        UnitAmountDecimal = cardVM.Card.Price * 100,
                        Currency = "USD"
                    }
                    /*
                     * (When we host live let's change the filePath to the URL)
                     * Images = new List<string> { filePath }
                    */
                };

                var result = service.Create(options);
                TradingCard card = cardVM.Card;

                foreach (int id in card.SelectedTypeId)
                {
                    card.Types.Add(typeDb.Get(id));
                }

                card.ProductId = result.Id;
                card.PriceId = result.DefaultPriceId;
                cardDb.Add(card);
                cardDb.Save();
                return RedirectToAction("Index");
            }
            GetModelProperties(ref cardVM);
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
            };
            GetModelProperties(ref cardVM);
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
                updatedCard.Year >= 1900 && updatedCard.Year <= DateTime.Now.Year &&
                updatedCard.ManufactuererId > 0 &&
                updatedCard.SportId > 0 &&
                updatedCard.TeamId > 0 &&
                updatedCard.SelectedTypeId != null &&
                updatedCard.SelectedTypeId.Count > 0 &&
                updatedCard.QualityId > 0)
            {
                var prodService = new ProductService();
                var priceService = new PriceService();
                
                if (cardVM.Card.Description == null)
                    cardVM.Card.Description = String.Empty;

                Product? product = null;
                try
                {
                    product = prodService.Get(updatedCard.ProductId);
                }
                catch (StripeException exc)
                {
                    ModelState.AddModelError("", exc.Message);
                    GetModelProperties(ref cardVM);
                    return View(cardVM);
                }

                Price? priceToUpdate = null;
                try
                {
                    priceToUpdate = priceService.Get(updatedCard.PriceId);
                }
                catch(StripeException exc)  // if for some reason all prices are deleted
                {
                    priceToUpdate = new Price();
                    Console.WriteLine(exc.Message);
                }

                decimal? calculatedPrice = updatedCard.Price * 100.00m;
                if(priceToUpdate.UnitAmountDecimal != calculatedPrice)
                {
                    var newPrice = priceService.Create(new PriceCreateOptions
                    {
                        UnitAmountDecimal = calculatedPrice,
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
                    DefaultPrice = product.DefaultPriceId,
                });
                updatedCard.PriceId = product.DefaultPriceId;
                cardDb.Update(updatedCard);
                cardDb.Save();
                return RedirectToAction("Index");
            }
            GetModelProperties(ref cardVM);
            return View(cardVM);
        }

        private void GetModelProperties(ref CardCreationVM cardCreationVM)
        {
            cardCreationVM.Sports = sportDb.List(new QueryOptions<Sport>());
            cardCreationVM.Manufacturers = manufacturerDb.List(new QueryOptions<Manufacturer>());
            cardCreationVM.Qualities = qualityDb.List(new QueryOptions<Quality>());
            cardCreationVM.Types = typeDb.List(new QueryOptions<CardType>());
            cardCreationVM.Teams = teamDb.List(new QueryOptions<Team>());
        }
    }
}
