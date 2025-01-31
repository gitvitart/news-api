using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NewsAPI.Entities;
using System.Data.Common;

namespace NewsAPI
{
    public class DataContext(string connectionString) : DbContext
    {
        private readonly string ConnectionString = connectionString;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString);

            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.ConfigureWarnings(builder => builder.Throw(RelationalEventId.MultipleCollectionIncludeWarning));

            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);

            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        ///     Попытаться асинхронно инициализировать сессию.
        ///     Используется для проверки подключения
        ///     и инициализации структуры таблиц.
        /// </summary>
        /// <returns>Статус успешности инициализации.</returns>
        public async Task<bool> TryInitializeAsync()
        {
            var canConnect = await Database.CanConnectAsync();
            var isCreated = await Database.EnsureCreatedAsync();

            return canConnect || isCreated;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new Author.Configuration());
            builder.ApplyConfiguration(new Topic.Configuration());
            builder.ApplyConfiguration(new Article.Configuration());
            base.OnModelCreating(builder);
        }

        public DbSet<Article> Articles => Set<Article>();
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<Topic> Topics => Set<Topic>();
    }
}
