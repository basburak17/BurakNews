using BurakNews.Core.DTOs;
using BurakNews.Core.Entities;

namespace BurakNews.Core.Services
{
    public interface INewService : IService<New>
    {
        Task<CustomResponseDto<List<NewWithCategoryDto>>> GetNewsWithCategory();
    }
}
