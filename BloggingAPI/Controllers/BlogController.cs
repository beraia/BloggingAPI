using BloggingAPI.Data;
using BloggingAPI.Models;
using BloggingAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloggingAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;
        public BlogController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [Authorize]
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromQuery]CreateArticleRequest request)
        {
            try
            {
                var response = await _articleService.Create(request);
                if(response.Success)
                {
                    return Ok(response);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500, "Server Error");
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetArticles([FromQuery]GetArticlesRequest request)
        {
            try
            {
                var response = await _articleService.GetArticles(request);
                if(response.Success)
                {
                    return Ok(response);
                }
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500, "Server Error");
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetArticleById([FromQuery]GetArticleByIdRequest request)
        {
            try
            {
                var response = await _articleService.GetArticleById(request);
                if (response != null)
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
