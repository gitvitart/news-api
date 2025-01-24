using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace NewsAPI
{
    public class DataContext(string connectionString) : DbContext
    {
        private readonly string ConnectionString = connectionString;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
