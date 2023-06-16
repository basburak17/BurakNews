using AutoMapper;
using BurakNews.Core.DTOs;
using BurakNews.Core.Entities;
using BurakNews.Core.Repositories;
using BurakNews.Core.Services;
using BurakNews.Core.UnitOfWorks;
using BurakNews.Repository.Repositories;

namespace BurakNews.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository categoryRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<CustomResponseDto<CategoryWithNewsDto>> GetSingleCategoryByIdWithNews(int categoryId)
        {
            var category = await _categoryRepository.GetSingleCategoryByIdWithNews(categoryId);
            var categoryDto = _mapper.Map<CategoryWithNewsDto>(category);
            return CustomResponseDto<CategoryWithNewsDto>.Success(200, categoryDto);
        }
    }
}
