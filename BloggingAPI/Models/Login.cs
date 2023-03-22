using System.ComponentModel.DataAnnotations;

namespace BloggingAPI.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? UserName { get; set; }


        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }

    public class LoginResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
