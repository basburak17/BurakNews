using AutoMapper;
using BurakNews.API.Filters;
using BurakNews.Core.DTOs;
using BurakNews.Core.Entities;
using BurakNews.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BurakNews.API.Controllers
{
    public class NewsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly INewService _service;

        public NewsController(IService<New> service, IMapper mapper, INewService newService)
        {
            _service = newService;
            _mapper = mapper;
        }
        [HttpGet("[action]")] // GET api/news/GetNewsWithCategory
        public async Task<IActionResult> GetNewsWithCategory()
        {
            return CreateActionResult(await _service.GetNewsWithCategory());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var news = await _service.GetAllAsync();
            var newsDto = _mapper.Map<List<NewDto>>(news).ToList();
            return CreateActionResult<List<NewDto>>(CustomResponseDto<List<NewDto>>.Success(200, newsDto)); // 200 Ok
        }
        [ServiceFilter(typeof(NotFoundFilter<New>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var news = await _service.GetByIdAsync(id);
            var newsDto = _mapper.Map<NewDto>(news);
            return CreateActionResult(CustomResponseDto<NewDto>.Success(200, newsDto)); // 200 Ok
        }
        [HttpPost]
        public async Task<IActionResult> Save(NewDto newDto)
        {
            var news = await _service.AddAsync(_mapper.Map<New>(newDto));
            var newsDto = _mapper.Map<NewDto>(news);
            return CreateActionResult(CustomResponseDto<NewDto>.Success(201, newsDto)); // 201 Created
        }
        [HttpPut]
        public async Task<IActionResult> Update(NewDto newDto)
        {
            await _service.UpdateAsync(_mapper.Map<New>(newDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204)); 
        }
        [ServiceFilter(typeof(NotFoundFilter<New>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var currentNew = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(currentNew);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204)); 
        }
    }
}
