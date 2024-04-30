using CardShop.Data;
using CardShop.Data.Repository;
using CardShop.Models;
using CardShop.Models.Domain;
using CardShop.Models.ExtensionMethods;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace CardShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repository<Sport> sportDb;

        public HomeController(ApplicationDbContext ctx)
        {
            sportDb = new Repository<Sport>(ctx);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetSports()
        {
            IEnumerable<Sport> sports = sportDb.List(new QueryOptions<Sport>()
            {
                OrderBy = c => c.Name
            });
            return Content(JsonSerializer.Serialize(sports));
        }

    }
}
