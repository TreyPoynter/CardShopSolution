namespace CardShop.Models.Domain
{
    public class PurchasedCard
    {
        public int CardId { get; set; }
        public int Amount { get; set; } = 0;
        public int PurchaseId { get; set; }
    }
}
