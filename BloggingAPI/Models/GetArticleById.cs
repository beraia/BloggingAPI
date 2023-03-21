namespace BloggingAPI.Models
{
    public class GetArticleByIdRequest
    {
        public Guid Id { get; set; }
    }
    public class GetArticleByIdResponse
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Success { get; set; }
    }
}
