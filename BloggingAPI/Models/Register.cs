﻿namespace BloggingAPI.Models
{
    public class RegisterRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class RegisterResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
