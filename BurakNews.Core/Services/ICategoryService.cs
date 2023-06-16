using BurakNews.Core.DTOs;
using BurakNews.Core.Entities;

namespace BurakNews.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        public Task<CustomResponseDto<CategoryWithNewsDto>> GetSingleCategoryByIdWithNews(int categoryId);
    }
}
