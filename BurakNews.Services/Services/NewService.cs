using AutoMapper;
using BurakNews.Core.DTOs;
using BurakNews.Core.Entities;
using BurakNews.Core.Repositories;
using BurakNews.Core.Services;
using BurakNews.Core.UnitOfWorks;

namespace BurakNews.Service.Services
{
    public class NewService : Service<New>, INewService
    {
        private readonly INewRepository _newRepository;
        private readonly IMapper _mapper;

        public NewService(IGenericRepository<New> repository, IUnitOfWork unitOfWork, INewRepository newRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _newRepository = newRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<NewWithCategoryDto>>> GetNewsWithCategory()
        {
            var news = await _newRepository.GetNewsWithCategory();
            var newsDto = _mapper.Map<List<NewWithCategoryDto>>(news);
            return CustomResponseDto<List<NewWithCategoryDto>>.Success(200,newsDto);
        }
    }
}
