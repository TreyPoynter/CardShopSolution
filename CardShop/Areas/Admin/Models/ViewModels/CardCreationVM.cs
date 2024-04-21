using CardShop.Models.Domain;

namespace CardShop.Areas.Admin.Models.ViewModels
{
    public class CardCreationVM : Card
    {
        public IEnumerable<Sport> Sports { get; set; } = null!;
        public IEnumerable<Rarity> Rarities { get; set; } = null!;
    }
}
