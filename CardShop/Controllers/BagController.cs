using CardShop.Data;
using CardShop.Data.Repository;
using CardShop.Models.Domain;
using CardShop.Models.ExtensionMethods;
using CardShop.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace CardShop.Controllers
{
    [Authorize]
    public class BagController : Controller
    {
        const string SESSION_KEY = "MyBag";
        private readonly IRepository<TradingCard> _cardDb;

        public BagController(ApplicationDbContext ctx)
        {
            _cardDb = new Repository<TradingCard>(ctx);
        }

        public IActionResult Index()
        {
            List<CartItem> cartItems = HttpContext.Session.Get<List<CartItem>>(SESSION_KEY) ?? new List<CartItem>();

            return View(new ShoppingCartVM()
            {
                CartItems = cartItems,
                TotalAmount = cartItems.Count,
                TotalPrice = cartItems.Sum(c => c.TradingCard.Price.Value * c.Amount)
            });
        }

        [HttpPost]
        public IActionResult AddToBag(int id, int numItems = 1)
        {
            TradingCard? addedItem = _cardDb.Get(id);

            List<CartItem> cartItems = HttpContext.Session.Get<List<CartItem>>(SESSION_KEY) ?? new List<CartItem>();

            CartItem? existingItem = cartItems.FirstOrDefault(c => c.TradingCard.Id == id);

            if (existingItem != null)
            {
                existingItem.Amount += numItems;
            }
            else
            {
                cartItems.Add(new CartItem
                {
                    TradingCard = addedItem,
                    Amount = numItems,
                });
            }

            HttpContext.Session.Set(SESSION_KEY, cartItems);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            List<CartItem> cartItems = HttpContext.Session.Get<List<CartItem>>(SESSION_KEY) ?? new List<CartItem>();
            CartItem? itemToRemove = cartItems.FirstOrDefault(b => b.TradingCard.Id == id);

            if (itemToRemove != null)
            {
                if (itemToRemove.Amount > 1)
                {
                    itemToRemove.Amount -= 1;
                }
                else
                {
                    cartItems.Remove(itemToRemove);
                }
            }

            HttpContext.Session.Set(SESSION_KEY, cartItems);
            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            List<CartItem> cartItems = HttpContext.Session.Get<List<CartItem>>(SESSION_KEY) ?? new List<CartItem>();
            var domain = "https://localhost:7109";
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>(),
                Mode = "payment",
                SuccessUrl = domain + "/Payment/Success",
                CancelUrl = domain + "",
            };
            foreach (CartItem item in cartItems)
            {
                SessionLineItemOptions sessionLine = new()
                {
                    Price = item.TradingCard.PriceId,
                    Quantity = item.Amount
                };
                options.LineItems.Add(sessionLine);
            }
            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }

        [HttpPost]
        public IActionResult ChangeQuantity(int amount, int id)
        {
            List<CartItem> cartItems = HttpContext.Session.Get<List<CartItem>>(SESSION_KEY) ?? new List<CartItem>();
            CartItem? item = cartItems.FirstOrDefault(i => i.TradingCard.Id == id);

            if (item != null)
            {
                item.Amount += amount;
                if (item.Amount < 1)
                {
                    cartItems.Remove(item);
                }
            }

            HttpContext.Session.Set(SESSION_KEY, cartItems);

            return RedirectToAction("Index");
        }

    }
}
