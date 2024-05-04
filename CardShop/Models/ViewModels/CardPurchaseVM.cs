using CardShop.Models.Domain;

namespace CardShop.Models.ViewModels
{
    public class CardPurchaseVM
    {
        public IEnumerable<IGrouping<Purchase, CardPurchase>> GroupedPurchases = null!;
    }
}
