using Microsoft.EntityFrameworkCore;
using NewsAPI.Entities;

namespace NewsAPI.Services
{
    public interface IDataEntityService<T> where T : IdentifiableEntity
    {
        Task<IEnumerable<T>> Get(DbSet<T> dbSet,List<int> ids);
        Task<bool> Set(DbSet<T> dbSet, List<T> entities);
        Task<bool> Delete(DbSet<T> dbSet, List<int> ids);
    }
}