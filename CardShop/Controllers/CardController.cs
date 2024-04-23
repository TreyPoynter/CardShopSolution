﻿using CardShop.Data;
using CardShop.Data.Repository;
using CardShop.Models;
using CardShop.Models.Domain;
using CardShop.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CardShop.Controllers
{
    public class CardController : Controller
    {
        private readonly Repository<TradingCard> _cardDb;

        public CardController(ApplicationDbContext ctx)
        {
            _cardDb = new Repository<TradingCard>(ctx);
        }

        [Route("/Cards/{id?}")]
        public IActionResult Index(string id)
        {
            CardCategoryVM cardsCategoryVM = new()
            {
                Category = id.Capitalize(),
                Cards = _cardDb.List(new QueryOptions<TradingCard>()
                {
                    OrderBy = c => c.Player,
                    Where = c => c.Sport.Name == id,
                    Includes = "Type, Quality, Manufacturer, Sport"
                })
            };

            return View(cardsCategoryVM);
        }

        [HttpPost]
        public IActionResult Search(string search)
        {
            CardCategoryVM cardsCategoryVM = new()
            {
                Category = search,
                Cards = _cardDb.List(new QueryOptions<TradingCard>()
                {
                    OrderBy = c => c.Player,
                    Includes = "Type, Quality, Manufacturer, Sport",
                }),
                IsSearching = true
            };
            cardsCategoryVM.Cards = _cardDb.Search(
                c => c.Player.ContainsNoCase(search) ||
                c.Description.ContainsNoCase(search) ||
                c.Type.Name.ContainsNoCase(search) ||
                c.Manufacturer.Name.ContainsNoCase(search) ||
                c.Sport.Name.ContainsNoCase(search));
            return View("Index", cardsCategoryVM);
        }
    }
}
