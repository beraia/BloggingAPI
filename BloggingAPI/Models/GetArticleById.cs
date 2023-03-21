namespace BloggingAPI.Models
{
    public class GetArticleByIdRequest
    {
        public Guid Id { get; set; } = Guid.Empty;
    }
    public class GetArticleByIdResponse
    {
        public string Title { get; set; }
        public string Content { get; set; }
}
    }
