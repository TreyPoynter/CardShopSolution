using CardShop.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardShop.Data.Configurations
{
    public class PurchaseConfig : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.HasOne(p => p.CardBought)
                .WithMany(c => c.Purchases);

            builder.HasOne(p => p.Buyer)
                .WithMany(u => u.Purchases);
        }
    }
}
