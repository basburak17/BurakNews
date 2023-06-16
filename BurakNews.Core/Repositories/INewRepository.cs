using BurakNews.Core.Entities;

namespace BurakNews.Core.Repositories
{
    public interface INewRepository : IGenericRepository<New>
    {
        Task<List<New>> GetNewsWithCategory();
    }
}
