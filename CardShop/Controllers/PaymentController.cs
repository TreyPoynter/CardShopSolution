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
        public IActionResult Success()
        {
            HttpContext.Session.Set("MyBag", new List<CartItem>());
            return View();
        }
        public IActionResult Cancel()
        {
            return View();
        }
    }
}
