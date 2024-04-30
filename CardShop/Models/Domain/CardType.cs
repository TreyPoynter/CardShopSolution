using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardShop.Models.Domain
{
    public class CardType
    {
        public int TypeId { get; set; }
        [Required]
        public string? Name { get; set; }
        [ForeignKey("CardId")]
        public ICollection<TradingCard> Cards { get; set; }

        public CardType()
        {
            Cards = new List<TradingCard>();
        }
    }
}
