namespace CardShop.Models.Domain
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public string? UserId { get; set; }
        public User? Buyer { get; set; }
        public int CardId { get; set; }
        public Card? CardBought { get; set; }
        public decimal Total { get; set; }
    }
}
