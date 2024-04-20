using CardShop.Models.Domain;

namespace CardShop.Areas.Admin.Models.ViewModels
{
    public class UserManagerVM
    {
        public IEnumerable<User> Users { get; set; }
    }
}
