﻿using System.ComponentModel.DataAnnotations;

namespace CardShop.Models.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "First Name is required")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Compare(nameof(ConfirmPassword), ErrorMessage = "Passwords must match")]
        public string? Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords must match")]
        public string? ConfirmPassword { get; set; }
    }
}
