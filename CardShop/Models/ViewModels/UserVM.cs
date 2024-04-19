using CardShop.Models.Domain;
using Microsoft.AspNetCore.Identity;

namespace CardShop.Models.ViewModels
{
    public class UserVM
    {
        public IList<User> Users { get; set; } = null!;
        public IList<IdentityRole> Roles { get; set; } = null!;
    }
}
