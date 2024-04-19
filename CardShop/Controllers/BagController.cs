using Microsoft.AspNetCore.Mvc;

namespace CardShop.Controllers
{
    public class BagController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
