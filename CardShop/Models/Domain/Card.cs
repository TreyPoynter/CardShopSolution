namespace CardShop.Models.Domain
{
    public class Card
    {
        public int Id { get; set; }
        public string? Player {  get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public bool IsForSale { get; set; } = false;
        public CardType? Type { get; set; }
        public uint? Number { get; set; }
        public string? ImageName { get; set; }
        public short? Year { get; set; }
        public Quality? Quality { get; set; }
        public Rarity? Rarity { get; set; }
        public Sport? Sport { get; set; }
    }
}
