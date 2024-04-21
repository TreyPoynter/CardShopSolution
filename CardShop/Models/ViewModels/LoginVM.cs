using System.ComponentModel.DataAnnotations;

namespace CardShop.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        public bool IsRemembered { get; set; } = false;
        public string? ReturnURL { get; set; }
    }
}
