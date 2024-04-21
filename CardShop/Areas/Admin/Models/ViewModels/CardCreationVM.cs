using CardShop.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace CardShop.Areas.Admin.Models.ViewModels
{
    public class CardCreationVM
    {
        [Display(Name = "Sport")]
        public IEnumerable<Sport> Sports { get; set; } = null!;
        [Display(Name = "Manufacturer")]
        public IEnumerable<Manufacturer> Manufacturers { get; set; } = null!;
        [Display(Name = "Quality")]
        public IEnumerable<Quality> Qualities { get; set; } = null!;

        public Card Card { get; set; }

        public CardCreationVM()
        {
            Card = new Card();
        }
    }
}
