namespace CardShop.Areas.Identity.Model.ViewModels
{
    public class LoginVM
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public bool IsRemembered { get; set; } = false;
    }
}
