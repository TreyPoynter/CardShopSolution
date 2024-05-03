using CardShop.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardShop.Data.Configurations
{
    public class CardPurchaseConfig : IEntityTypeConfiguration<CardPurchase>
    {
        public void Configure(EntityTypeBuilder<CardPurchase> builder)
        {
            builder.HasKey(p => p.CardPurchaseId);

            builder.HasOne(p => p.TradingCard)
                .WithMany(c => c.CardPurchases);

            builder.HasOne(p => p.Purchase)
                .WithMany(c => c.CardPurchases);
        }
    }
}
