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
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValue("current_timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .IsRequired(IsCreatedAtRequired);

                builder.Property(entity => entity.UpdatedAt)
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValue("current_timestamp")
                    .IsRequired(IsUpdatedAtRequired);
            }
        }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
