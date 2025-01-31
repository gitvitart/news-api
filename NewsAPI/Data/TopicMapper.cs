using NewsAPI.Entities;

namespace NewsAPI.Data
{
    public static class TopicMapper
    {
        public static Topic ToEntity(this TopicDTO topic)
        {
            return new Topic()
            {
                Id = topic.Id,
                Title = topic.Title,
                UpdatedAt = topic.UpdatedAt,
                CreatedAt = topic.CreatedAt
            };
        }

        public static TopicDTO ToDTO(this Topic topic)
        {
            return new TopicDTO()
            {
                Id = topic.Id,
                Title = topic.Title,
                UpdatedAt = topic.UpdatedAt,
                CreatedAt = topic.CreatedAt
            };

        }
    }
}
