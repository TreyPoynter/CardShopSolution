using System.ComponentModel.DataAnnotations.Schema;

namespace CardShop.Models.Domain
{
    public class Card
    {
        public int Id { get; set; }
        public string? Player {  get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public bool IsForSale { get; set; } = false;
        public int TypeId { get; set; }
        [ForeignKey(nameof(TypeId))]
        public CardType? Type { get; set; }
        public uint? Number { get; set; }
        public string? ImageName { get; set; }
        public short? Year { get; set; }
        public int QualityId { get; set; }
        [ForeignKey(nameof(QualityId))]
        public Quality? Quality { get; set; }
        public int ManufactuererId { get; set; }
        [ForeignKey(nameof(ManufactuererId))]
        public Manufacturer? Manufacturer { get; set; }
        public int SportId { get; set; }
        [ForeignKey(nameof(SportId))]
        public Sport? Sport { get; set; }
        public IEnumerable<Purchase> Purchases { get; set; }

        public Card()
        {
            Purchases = new List<Purchase>();
        }
    }
}
