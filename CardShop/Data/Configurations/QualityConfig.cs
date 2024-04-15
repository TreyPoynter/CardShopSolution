using CardShop.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardShop.Data.Configurations
{
    public class QualityConfig : IEntityTypeConfiguration<Quality>
    {
        public void Configure(EntityTypeBuilder<Quality> builder)
        {
            builder.HasData(
                new Quality() { QualityId = 1, Type = "Mint"},
                new Quality() { QualityId = 2, Type = "Near Mint"},
                new Quality() { QualityId = 3, Type = "Excellent"},
                new Quality() { QualityId = 4, Type = "Very Good"},
                new Quality() { QualityId = 5, Type = "Good"},
                new Quality() { QualityId = 6, Type = "Fair"},
                new Quality() { QualityId = 7, Type = "Poor"},
                new Quality() { QualityId = 8, Type = "Damaged"}
                );
        }
    }
}
