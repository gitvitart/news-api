using NewsAPI.Entities;

namespace NewsAPI.Services
{
    public class TopicService(DataContext context) : DataEntityService<Topic>(context)
    {
    }
}
