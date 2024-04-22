using CardShop.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardShop.Data.Configurations
{
    public class CardConfig : IEntityTypeConfiguration<TradingCard>
    {
        public void Configure(EntityTypeBuilder<TradingCard> builder)
        {
            builder.HasMany(c => c.Purchases)
                .WithOne(p => p.CardBought);
        }
    }
}
