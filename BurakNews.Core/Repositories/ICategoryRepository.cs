using BurakNews.Core.Entities;

namespace BurakNews.Core.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<Category> GetSingleCategoryByIdWithNews(int categoryId);
    }
}
