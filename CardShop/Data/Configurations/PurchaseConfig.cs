using CardShop.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardShop.Data.Configurations
{
    public class PurchaseConfig : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasKey(p => p.PurchaseId);

            builder.HasMany(p => p.CardPurchases)
                .WithOne(p => p.Purchase);

            builder.HasOne(p => p.Buyer)
                .WithMany(u => u.Purchases);
        }
    }
}
