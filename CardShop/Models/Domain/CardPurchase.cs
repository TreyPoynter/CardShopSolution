using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardShop.Models.Domain
{
    public class CardPurchase
    {
        [Key]
        public int CardPurchaseId { get; set; }
        public int TradingCardId { get; set; }
        [ForeignKey(nameof(TradingCardId))]
        public TradingCard TradingCard { get; set; } = null!;

        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; } = null!;

        public int Quantity { get; set; }
    }
}
