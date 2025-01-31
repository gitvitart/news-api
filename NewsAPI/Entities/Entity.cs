using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NewsAPI.Entities
{
    public abstract class Entity
    {
        private const bool IsCreatedAtRequired = false;
        private const bool IsUpdatedAtRequired = false;

        internal abstract class Configuration<T>() : IEntityTypeConfiguration<T> where T : Entity
        {
            public virtual void Configure(EntityTypeBuilder<T> builder)
            {
                builder.Property(entity => entity.CreatedAt)
                    .IsRequired(IsCreatedAtRequired);

                builder.Property(entity => entity.UpdatedAt)
                    .IsRequired(IsUpdatedAtRequired);
            }
        }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
