using BloggingAPI.Models;

namespace BloggingAPI.Services
{
    public interface IUserService
    {
        Task<RegisterResponse> Register(RegisterRequest request);
    }
}
