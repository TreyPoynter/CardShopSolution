using Microsoft.AspNetCore.Mvc;

namespace CardShop.Areas.Admin.Controllers
{
    public class TeamController : Controller
    {
        [Route("{area}/Teams")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
