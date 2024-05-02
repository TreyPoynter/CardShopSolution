﻿using System.ComponentModel.DataAnnotations.Schema;

namespace CardShop.Models.Domain
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public string? UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? Buyer { get; set; }
        public ICollection<TradingCard> CardsBought { get; set; }
        public DateTime DatePurchased { get; set; } = DateTime.Now;
        public decimal Total { get; set; }

        public Purchase()
        {
            CardsBought = new List<TradingCard>();
        }
    }
}
