using BloggingAPI.Data;
using BloggingAPI.Models;
using Ganss.Xss;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloggingAPI.Services
{
    public class ArticleService : IArticleService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        public ArticleService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _context= context;
            _httpContextAccessor= httpContextAccessor;
            _userManager= userManager;
        }
        public async Task<CreateArticleResponse> Create(CreateArticleRequest request)
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;

            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);


            Article article = new()
            {
                Title = request.Title,
                Content = request.Content,
            };

            var sanitizer = new HtmlSanitizer();
            var sanitized = sanitizer.Sanitize(article.Content);

            _context.Articles.Add(article);
            _context.SaveChanges();
            return new CreateArticleResponse() { Success = true };
        }

        public async Task<GetArticleByIdResponse> GetArticleById(GetArticleByIdRequest request)
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;

            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);

            var article = await _context.Articles.FirstOrDefaultAsync(x => x.Id == request.Id);
            if(article == null)
            {
                return new GetArticleByIdResponse { Success = false };
            }
            return new GetArticleByIdResponse()
            {
                Title = article.Title,
                Content = article.Content,
            };
        }

        public async Task<GetArticlesResponse> GetArticles(GetArticlesRequest request)
        {
            var userName = _httpContextAccessor.HttpContext.User.Identity.Name;

            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);

            var articlesQuery = _context.Articles.Select(x => x);
            var articles = articlesQuery.Select(x => new GetArticlesResponse.Article
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content
            });
            return new GetArticlesResponse()
            {
                Success = true,
                Articles = articles.ToList(),
            };
        }
    }
}
