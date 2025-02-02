namespace NewsAPI.Data
{
    public record TopicDTO : IdentifiableEntityDTO
    {
        public string? Title { get; set; }
    }
}
