namespace BloggingAPI.Models
{
    public class CreateArticleRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
    public class CreateArticleResponse
    {
        public bool Success { get; set; }
    }
}
