using BurakNews.Core.Entities;
using BurakNews.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BurakNews.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetSingleCategoryByIdWithNews(int categoryId)
        {
            return await _context.Categories.Include(x => x.News).Where(x => x.Id == categoryId).SingleOrDefaultAsync();
        }
    }
}
