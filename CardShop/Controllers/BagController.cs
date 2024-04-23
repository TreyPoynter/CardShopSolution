using Microsoft.AspNetCore.Mvc;

namespace CardShop.Controllers
{
    public class BagController : Controller
    {
        const string SESSION_KEY = "MyBag";

        public IActionResult Index()
        {
            return View();
        }
    }
}
