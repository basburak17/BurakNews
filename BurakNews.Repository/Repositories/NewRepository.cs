using BurakNews.Core.Entities;
using BurakNews.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BurakNews.Repository.Repositories
{
    public class NewRepository : GenericRepository<New>, INewRepository
    {
        public NewRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<New>> GetNewsWithCategory()
        {
            return await _context.News.Include(x => x.Category).ToListAsync();
        }
    }
}
