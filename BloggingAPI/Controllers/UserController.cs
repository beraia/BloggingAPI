using BloggingAPI.Models;
using BloggingAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloggingAPI.Controllers
{
    [Authorize]
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
        [AllowAnonymous]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            try
            {
                var response = await _userService.Login(request);
                if(response == null)
                {
                    return Unauthorized();
                }
                return Ok(response);
            }
            catch (Exception)
            {
                return StatusCode(500, "Server Error");
            }
        }

        [HttpPost]
        [AllowAnonymous]
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
