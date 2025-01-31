using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NewsAPI.Entities
{
    public class Article : IdentifiableEntity
    {

        private const bool IsTitleRequired = true;
        private const int TitleMaxLength = 256;
        private const bool IsContentRequired = true;
        private const int ContentMaxLength = 1000;
        private const bool IsTopicRequired = true;
        private const bool IsAuthorRequired = true;

        internal class Configuration() : Configuration<Article>()
        {
            public override void Configure(EntityTypeBuilder<Article> builder)
            {
                builder.Property(article => article.Title)
                    .HasMaxLength(TitleMaxLength)
                    .IsRequired(IsTitleRequired);

                builder.Property(article => article.Content)
                    .HasMaxLength(ContentMaxLength)
                    .IsRequired(IsContentRequired);

                builder.HasOne(article => article.Topic)
                    .WithMany(topic => topic.Articles)
                    .HasForeignKey(article => article.TopicId)
                    .IsRequired(IsTopicRequired);

                builder.HasOne(article => article.Author)
                    .WithMany(topic => topic.Articles)
                    .HasForeignKey(article => article.AuthorId)
                    .IsRequired(IsTopicRequired);

                base.Configure(builder);
            }
        }

        public string? Title { get; set; } = string.Empty;
        public string Content{ get; set; } = string.Empty;

        public int TopicId { get; set; }
        public int AuthorId { get; set; }

        public Topic? Topic{ get; set; }
        public Author? Author{ get; set; }
    }
}
