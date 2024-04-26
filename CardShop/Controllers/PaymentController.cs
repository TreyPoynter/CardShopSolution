using CardShop.Data;
using CardShop.Data.Repository;
using CardShop.Models.Domain;
using CardShop.Models.ExtensionMethods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace CardShop.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly Repository<TradingCard> cardDb;

        public PaymentController(ApplicationDbContext ctx)
        {
            cardDb = new Repository<TradingCard>(ctx);
        }

        public IActionResult Success()
        {
            HttpContext.Session.Set("MyBag", new List<CartItem>());
            return View();
        }
        public IActionResult Cancel()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckoutNow(int cardId)
        {
            TradingCard? card = cardDb.Get(cardId);

            if (card == null)
                return RedirectToAction("Index", "Home");

            var domain = "https://localhost:7109";
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
