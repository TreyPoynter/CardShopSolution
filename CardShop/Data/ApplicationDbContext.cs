using CardShop.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CardShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<Quality> Qualities { get; set; }
        public DbSet<Rarity> Rarities { get; set; }
        public DbSet<Sport> Sports { get; set; }
    }
}
