﻿namespace SensorLogger.Models
{
    public class CreateNewAccountModel
    {
        public bool Created { get; set; }
        public string Error { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}