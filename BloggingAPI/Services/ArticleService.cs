using BloggingAPI.Data;
using BloggingAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloggingAPI.Services
{
    public class ArticleService : IArticleService
    {
        private readonly ApplicationDbContext _context;
        public ArticleService(ApplicationDbContext context)
        {
            _context= context;
        }
        public async Task<CreateArticleResponse> Create(CreateArticleRequest request)
        {
            Article article = new()
            {
                Title = request.Title,
                Content = request.Content,
            };
            _context.Articles.Add(article);
            _context.SaveChanges();
            return new CreateArticleResponse() { Success = true };
        }

        public async Task<GetArticleByIdResponse> GetArticleById(GetArticleByIdRequest request)
        {
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
