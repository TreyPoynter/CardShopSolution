﻿namespace CardShop.Models.ViewModels
{
    public class LoginVM
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool IsRemembered { get; set; } = false;
    }
}
