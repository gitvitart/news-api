namespace NewsAPI.Data
{
    public record AuthorDTO : IdentifiableEntityDTO
    {
        public string? Name { get; set; }
    }
}
