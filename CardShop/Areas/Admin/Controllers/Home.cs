using Microsoft.AspNetCore.Mvc;

namespace CardShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Home : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
