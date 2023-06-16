using AutoMapper;
using BurakNews.Core.DTOs;
using BurakNews.Core.Entities;
using BurakNews.Core.Repositories;
using BurakNews.Core.Services;
using BurakNews.Core.UnitOfWorks;
using BurakNews.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Linq.Expressions;

namespace BurakNews.Caching
{
    public class NewServiceWithCaching : INewService
    {
        private const string CacheNewKey = "newsKey";
        private readonly IMemoryCache _memoryCache;
        private readonly INewRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NewServiceWithCaching(IMapper mapper, IMemoryCache memoryCache, INewRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
            _repository = repository;
            _unitOfWork = unitOfWork;
            if (!_memoryCache.TryGetValue(CacheNewKey, out _))
            {
                _memoryCache.Set(CacheNewKey, _repository.GetNewsWithCategory().Result);
            }
        }


        public async Task<New> AddAsync(New entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllNewsAsync();
            return entity;
        }

        public async Task<IEnumerable<New>> AddRangeAsync(IEnumerable<New> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllNewsAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<New, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<New>> GetAllAsync()
        {
            return Task.FromResult(_memoryCache.Get<IEnumerable<New>>(CacheNewKey));
        }

        public Task<New> GetByIdAsync(int id)
        {
            var result = _memoryCache.Get<List<New>>(CacheNewKey).FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                throw new NotFoundException($"{typeof(New).Name}-({id}) not found!");
            }

            return Task.FromResult(result);
        }

        public Task<CustomResponseDto<List<NewWithCategoryDto>>> GetNewsWithCategory()
        {
            var news = _memoryCache.Get<IEnumerable<New>>(CacheNewKey);

            var newsWithCategoryDto = _mapper.Map<List<NewWithCategoryDto>>(news);

            return Task.FromResult(CustomResponseDto<List<NewWithCategoryDto>>.Success(200,newsWithCategoryDto));
        }

        public async Task RemoveAsync(New entity)
        {
            _repository.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllNewsAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<New> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllNewsAsync();
        }

        public async Task UpdateAsync(New entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllNewsAsync();
        }

        public IQueryable<New> Where(Expression<Func<New, bool>> expression)
        {
            return _memoryCache.Get<List<New>>(CacheNewKey).Where(expression.Compile()).AsQueryable();
        }

        public async Task CacheAllNewsAsync()
        {
            _memoryCache.Set(CacheNewKey, await _repository.GetAll().ToListAsync());
        }
    }
}
