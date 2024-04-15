using CardShop.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardShop.Data.Configurations
{
    public class SportConfig : IEntityTypeConfiguration<Sport>
    {
        public void Configure(EntityTypeBuilder<Sport> builder)
        {
            builder.HasData(
                new Sport() { SportId = 1, Name = "Baseball"},
                new Sport() { SportId = 2, Name = "Football"},
                new Sport() { SportId = 3, Name = "Hockey"},
                new Sport() { SportId = 4, Name = "Golf"},
                new Sport() { SportId = 5, Name = "Wrestling"},
                new Sport() { SportId = 6, Name = "Racing"},
                new Sport() { SportId = 7, Name = "Boxing"},
                new Sport() { SportId = 8, Name = "MMA"}
                );
        }
    }
}
