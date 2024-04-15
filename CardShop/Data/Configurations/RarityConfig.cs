using CardShop.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardShop.Data.Configurations
{
    public class RarityConfig : IEntityTypeConfiguration<Rarity>
    {
        public void Configure(EntityTypeBuilder<Rarity> builder)
        {
            builder.HasData(
                new Rarity() { RarityId = 1, Name = "Common" },
                new Rarity() { RarityId = 2, Name = "Uncommon" },
                new Rarity() { RarityId = 3, Name = "Rare" },
                new Rarity() { RarityId = 4, Name = "Super Rare" },
                new Rarity() { RarityId = 5, Name = "Legendary" },
                new Rarity() { RarityId = 6, Name = "Special Edition" },
                new Rarity() { RarityId = 7, Name = "Promotional" },
                new Rarity() { RarityId = 8, Name = "Collectors Edition" },
                new Rarity() { RarityId = 9, Name = "Team Spirit" },
                new Rarity() { RarityId = 10, Name = "All Star" });
        }
    }
}
