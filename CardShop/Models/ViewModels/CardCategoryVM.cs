using CardShop.Models.Domain;

namespace CardShop.Models.ViewModels
{
    public class CardCategoryVM
    {
        public string? Category { get; set; }

        public IEnumerable<TradingCard> Cards { get; set; } = null!;

        public CardCategoryVM()
        {
            Cards = new List<TradingCard>();
        }
    }
}
