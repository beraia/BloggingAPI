using BloggingAPI.Data;
using BloggingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloggingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateArticle(CreateArticleRequest request)
        {
            var article = new Article()
            {
                Title = request.Title,
                Content = request.Content,
            };
            _context.Add(article);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetArticles()
        {
            var result = await _context.Articles.ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetArticleById([FromQuery]GetArticleByIdRequest request)
        {
            var article = await _context.Articles.FirstOrDefaultAsync(x => x.Id == request.Id);
            var result = new GetArticleByIdResponse()
            {
                Title = article.Title,
                Content = article.Content,
            };
            return Ok(result);
        }
    }
}
