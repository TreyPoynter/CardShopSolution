using CardShop.Models.Domain;

namespace CardShop.Models.ViewModels
{
    public class ShoppingCartVM
    {
        public List<CartItem> CartItems { get; set; }

        public decimal TotalPrice { get; set; }
        public int TotalAmount { get; set; }

        public ShoppingCartVM()
        {
            CartItems = new List<CartItem>();
        }
    }
}
