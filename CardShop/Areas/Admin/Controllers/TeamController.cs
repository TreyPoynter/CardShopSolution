using CardShop.Areas.Admin.Models.ViewModels;
using CardShop.Data;
using CardShop.Data.Repository;
using CardShop.Models;
using CardShop.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CardShop.Areas.Admin.Controllers
{
    public class TeamController : Controller
    {
        private Repository<Team> teamDb { get; set; }

        public TeamController(ApplicationDbContext ctx)
        {
            teamDb = new Repository<Team>(ctx);
        }

        [Route("{area}/Teams")]
        public IActionResult Index(string searchString = "")
        {
            SearchVM<Team> model = new SearchVM<Team>()
            {
                Search = searchString,
                Items = teamDb.List(new QueryOptions<Team>())
            };

            if (searchString != String.Empty)
                model.Items = model.Items.Where(c => c.Name.ContainsNoCase(searchString) ||
                    c.Name.ContainsNoCase(searchString)).ToList();

            return View(model);
        }
    }
}
