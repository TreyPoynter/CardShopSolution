using CardShop.Models.Domain;

namespace CardShop.Models.ViewModels
{
    public class CardCategoryVM
    {
        public string? Category { get; set; }

        public IEnumerable<Card> Cards { get; set; } = null!;

        public CardCategoryVM()
        {
            Cards = new List<Card>();
        }
    }
}
