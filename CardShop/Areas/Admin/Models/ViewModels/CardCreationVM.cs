using CardShop.Models.Domain;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace CardShop.Areas.Admin.Models.ViewModels
{
    public class CardCreationVM
    {
        [Required(ErrorMessage = "Image is required")]
        public IFormFile Image { get; set; }

        [Display(Name = "Sport")]
        [ValidateNever]
        public IEnumerable<Sport> Sports { get; set; } = null!;
        [Display(Name = "Manufacturer")]
        [ValidateNever]
        public IEnumerable<Manufacturer> Manufacturers { get; set; } = null!;
        [Display(Name = "Quality")]
        [ValidateNever]
        public IEnumerable<Quality> Qualities { get; set; } = null!;
        [Display(Name = "Types")]
        [ValidateNever]
        public IEnumerable<CardType> Types { get; set; } = null!;
        [Display(Name = "Team")]
        [ValidateNever]
        public IEnumerable<Team> Teams { get; set; } = null!;


        public TradingCard Card { get; set; }

        public CardCreationVM()
        {
            Card = new TradingCard();
        }
    }
}
