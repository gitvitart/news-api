using NewsAPI.Entities;

namespace NewsAPI.Services
{
    public class AuthorService(DataContext context) : DataEntityService<Author>(context)
    {
    }
}
