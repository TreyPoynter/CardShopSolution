using CardShop.Data;
using CardShop.Data.Repository;
using CardShop.Models.Domain;
using CardShop.Models.ExtensionMethods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace CardShop.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly Repository<TradingCard> cardDb;
        private readonly Repository<Purchase> purchaseDb;
        private readonly UserManager<User> userManager;

        public PaymentController(ApplicationDbContext ctx, UserManager<User> userMan)
        {
            cardDb = new Repository<TradingCard>(ctx);
            purchaseDb = new Repository<Purchase>(ctx);
            userManager = userMan;
        }

        public IActionResult Success()
        {
            List<CartItem> cartItems = HttpContext.Session.Get<List<CartItem>>("MyBag") ?? new List<CartItem>();
            if(cartItems.Count > 0)
            {
                foreach (var item in cartItems)
                {
                    Purchase newPurchase = new()
                    {
                        UserId = userManager.GetUserId(User),
                        CardId = item.TradingCard.Id,
                        Total = (decimal)item.TradingCard.Price * item.Amount
                    };
                    purchaseDb.Add(newPurchase);
                    purchaseDb.Save();
                }
            }
            

            HttpContext.Session.Set("MyBag", new List<CartItem>());
            return View();
        }
        public IActionResult Cancel()
        {
            return View("Index", "Home");
        }
        [HttpPost]
        public IActionResult CheckoutNow(int cardId)
        {
            TradingCard? card = cardDb.Get(cardId);

            if (card == null)
                return RedirectToAction("Index", "Home");

            List<CartItem> cartItems = HttpContext.Session.Get<List<CartItem>>("MyBag") ?? new List<CartItem>();
            cartItems.Add(new CartItem()
            {
                TradingCard = card,
                Amount = 1
            });
            HttpContext.Session.Set("MyBag", cartItems);
            var domain = "https://localhost:7138";
            var options = new SessionCreateOptions
            {
                BillingAddressCollection = "required",
                Mode = "payment",
                SuccessUrl = domain + "/Payment/Success",
                CancelUrl = domain + "",
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        Price = card.PriceId,
                        Quantity = 1
                    }
                }
            };
            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }
    }
}
