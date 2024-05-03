using CardShop.Data.Configurations;
using CardShop.Models.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CardShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TradingCard> Cards { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<Quality> Qualities { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<CardPurchase> CardPurchases { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CardConfig());
            builder.ApplyConfiguration(new CardTypeConfig());
            builder.ApplyConfiguration(new PurchaseConfig());
            builder.ApplyConfiguration(new QualityConfig());
            builder.ApplyConfiguration(new ManufacturerConfig());
            builder.ApplyConfiguration(new SportConfig());
            builder.ApplyConfiguration(new TeamConfig());
            builder.ApplyConfiguration(new CardPurchaseConfig());
        }
    }
}
