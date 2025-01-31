using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static NewsAPI.Entities.Entity;

namespace NewsAPI.Entities
{
    public class Topic : IdentifiableEntity
    {
        private const bool IsTitleRequired = true;
        private const int TitleMaxLength = 256;

        internal class Configuration() : Configuration<Topic>()
        {
            public override void Configure(EntityTypeBuilder<Topic> builder)
            {
                builder.Property(author => author.Title)
                    .HasMaxLength(TitleMaxLength)
                    .IsRequired(IsTitleRequired);

                base.Configure(builder);
            }
        }

        public string? Title { get; set; } = string.Empty;
        public List<Article> Articles { get; set; } = [];
    }
}
