using CardShop.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardShop.Data.Configurations
{
    public class CardTypeConfig : IEntityTypeConfiguration<CardType>
    {
        public void Configure(EntityTypeBuilder<CardType> builder)
        {
            builder.HasKey(c => c.TypeId);

            builder.HasData(
                new CardType() { TypeId = 1, Name = "Base"},
                new CardType() { TypeId = 2, Name = "Rookie"},
                new CardType() { TypeId = 3, Name = "Insert"},
                new CardType() { TypeId = 4, Name = "Autographed"},
                new CardType() { TypeId = 5, Name = "Relic"},
                new CardType() { TypeId = 6, Name = "Parallel"},
                new CardType() { TypeId = 7, Name = "Memorabillia"},
                new CardType() { TypeId = 8, Name = "Promotional"},
                new CardType() { TypeId = 9, Name = "Chase"},
                new CardType() { TypeId = 10, Name = "Box Topper"}
                );
        }
    }
}
