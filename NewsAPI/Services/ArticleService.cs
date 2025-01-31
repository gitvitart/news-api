using NewsAPI.Entities;

namespace NewsAPI.Services
{
    public class ArticleService(DataContext context) : DataEntityService<Article>(context)
    {
    }
}
