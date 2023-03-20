using BloggingAPI.Data;
using BloggingAPI.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult CreateArticle(CreateArticleRequest request)
        {
            var article = new Article()
            {
                Title = request.Title,
                Content = request.Content,
            };
            _context.Add(article);
            _context.SaveChanges();
            return Ok();
        }
    }
}
