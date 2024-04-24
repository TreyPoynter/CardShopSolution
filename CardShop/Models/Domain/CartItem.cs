namespace CardShop.Models.Domain
{
    public class CartItem
    {
        public string? Id { get; set; }
        public TradingCard TradingCard { get; set; }

        public int Amount { get; set; }
    }
}
