namespace BloggingAPI.Models
{
    public class GetArticlesRequest
    {
    }
    public class GetArticlesResponse
    {
        public List<Article> Articles { get; set; } = new List<Article>();

        public class Article
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
        }
        public bool Success { get; set; }
    }
}
