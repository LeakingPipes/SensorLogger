﻿namespace SensorLogger.Models
{
    public class LoginModel
    {
        public string ErrorMessage { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
    }
}
