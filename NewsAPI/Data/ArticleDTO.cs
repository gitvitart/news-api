namespace NewsAPI.Data
{
    public record ArticleDTO : IdentifiableEntityDTO
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int? TopicId { get; set; }
        public int? AuthorId { get; set; }
    }
}
