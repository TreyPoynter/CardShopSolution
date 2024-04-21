using CardShop.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardShop.Data.Configurations
{
    public class ManufacturerConfig : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.HasData(
                new Manufacturer() { ManufacturerId = 1, Name = "Topps" },
                new Manufacturer() { ManufacturerId = 2, Name = "Panini" },
                new Manufacturer() { ManufacturerId = 3, Name = "Upper Deck" },
                new Manufacturer() { ManufacturerId = 4, Name = "Bowman" },
                new Manufacturer() { ManufacturerId = 5, Name = "Leaf Trading Cards" },
                new Manufacturer() { ManufacturerId = 6, Name = "Donruss" },
                new Manufacturer() { ManufacturerId = 7, Name = "Score" },
                new Manufacturer() { ManufacturerId = 8, Name = "Fleer" },
                new Manufacturer() { ManufacturerId = 9, Name = "Pro Set" },
                new Manufacturer() { ManufacturerId = 10, Name = "Tristar" });
        }
    }
}
