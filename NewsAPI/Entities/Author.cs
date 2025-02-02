using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NewsAPI.Entities
{
    public class Author : IdentifiableEntity
    {
        private const bool IsNameRequired = true;
        private const int NameMaxLength = 256;

        internal class Configuration():Configuration<Author>()        {
            public override void Configure(EntityTypeBuilder<Author> builder)
            {
                builder.Property(author => author.Name)
                    .HasMaxLength(NameMaxLength)
                    .IsRequired(IsNameRequired);

                base.Configure(builder);
            }
        }

        public string? Name { get; set; } = string.Empty;
        public List<Article> Articles { get; set; } = [];
    }
}
