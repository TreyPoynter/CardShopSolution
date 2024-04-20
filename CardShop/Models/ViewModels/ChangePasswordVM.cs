using System.ComponentModel.DataAnnotations;

namespace CardShop.Models.ViewModels
{
    public class ChangePasswordVM
    {
        public string Email { get; set; } = String.Empty;
        [Required]
        [Display(Name = "Old Password")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; } = String.Empty;
        [Required]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; } = String.Empty;
        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = String.Empty;
    }
}
