using BloggingAPI.Models;

namespace BloggingAPI.Services
{
    public interface IArticleService
    {
        Task<CreateArticleResponse> Create(CreateArticleRequest request);
        Task<GetArticlesResponse> GetArticles(GetArticlesRequest request);
        Task<GetArticleByIdResponse> GetArticleById(GetArticleByIdRequest request);
    }
}
