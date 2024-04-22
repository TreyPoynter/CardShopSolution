using System.ComponentModel.DataAnnotations.Schema;

namespace CardShop.Models.Domain
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public string? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? Buyer { get; set; }
        public int CardId { get; set; }
        [ForeignKey(nameof(CardId))]
        public TradingCard? CardBought { get; set; }
        public decimal Total { get; set; }
    }
}
