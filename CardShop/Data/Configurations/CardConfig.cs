using CardShop.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardShop.Data.Configurations
{
    public class CardConfig : IEntityTypeConfiguration<TradingCard>
    {
        public void Configure(EntityTypeBuilder<TradingCard> builder)
        {
            builder.HasMany(p => p.Purchases)
                 .WithMany(t => t.CardsBought)
                 .UsingEntity<Dictionary<string, object>>(
                     "PurchasedCards",
                     pc => pc.HasOne<Purchase>()
                         .WithMany()
                         .HasForeignKey("PurchaseId")
                         .OnDelete(DeleteBehavior.Restrict),
                     pc => pc.HasOne<TradingCard>()
                         .WithMany()
                         .HasForeignKey("CardId")
                         .OnDelete(DeleteBehavior.Restrict));

            builder.HasMany(c => c.Types)
                .WithMany(t => t.Cards)
                .UsingEntity<Dictionary<string, object>>(
                    "TypesOfCards",
                    ba => ba.HasOne<CardType>()
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Restrict),
                    ba => ba.HasOne<TradingCard>()
                        .WithMany()
                        .HasForeignKey("CardId")
                        .OnDelete(DeleteBehavior.Restrict));
        }
    }
}
