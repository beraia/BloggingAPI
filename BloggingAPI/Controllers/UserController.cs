using BloggingAPI.Models;
using BloggingAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BloggingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            try
            {
                var response = await _userService.Register(request);
                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }
            catch (Exception)
            {
                return StatusCode(500, "Server Error");            
            }
        }
    }
}
