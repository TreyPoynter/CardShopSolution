using Microsoft.AspNetCore.Identity;

namespace CardShop.Models.Domain
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName => $"{FirstName} {LastName}";

        public IEnumerable<Purchase> Purchases { get; set; } = null!;

        public User()
        {
            Purchases = new List<Purchase>();
        }
    }
}
