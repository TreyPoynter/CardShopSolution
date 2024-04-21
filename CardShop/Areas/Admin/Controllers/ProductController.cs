using CardShop.Areas.Admin.Models.ViewModels;
using CardShop.Data;
using CardShop.Data.Repository;
using CardShop.Models;
using CardShop.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CardShop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ProductController : Controller
    {
        private Repository<Card> cardDb {  get; set; }
        private Repository<Sport> sportDb {  get; set; }

        public ProductController(ApplicationDbContext ctx)
        {
            cardDb = new Repository<Card>(ctx);
            sportDb = new Repository<Sport>(ctx);
        }

        [Route("{area}/Products")]
        public IActionResult Index(string search = "")
        {
            SearchVM<Card> model = new SearchVM<Card>()
            {
                Search = search,
                Items = cardDb.List(new QueryOptions<Card>())
            };

            if(search != String.Empty)
                model.Items = model.Items.Where(c => c.Sport.Name.ContainsNoCase(search) ||
                    c.Player.ContainsNoCase(search)).ToList();

            return View(model);
        }
        [Route("{area}/Product/Add")]
        public IActionResult Add()
        {
            return View(new Card());
        }
    }
}
