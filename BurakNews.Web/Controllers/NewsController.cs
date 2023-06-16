using AutoMapper;
using BurakNews.Core.DTOs;
using BurakNews.Core.Entities;
using BurakNews.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BurakNews.Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewService _services;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public NewsController(INewService services, ICategoryService categoryService, IMapper mapper)
        {
            _services = services;
            _categoryService = categoryService;
            _mapper = mapper;

        }
        public async Task<IActionResult> Index()
        {
            return View((await _services.GetNewsWithCategory()).Data);
        }
        [HttpGet]
        public async Task<IActionResult> Save()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(NewDto newDto)
        {
            if (ModelState.IsValid)
            {
                await _services.AddAsync(_mapper.Map<New>(newDto));
                return RedirectToAction(nameof(Index));
            }

            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");

            return View();
        }

        [ServiceFilter(typeof(NotFoundFilter<New>))]
        public async Task<IActionResult> Update(int id)
        {
            var news = await _services.GetByIdAsync(id);

            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name", news.CategoryId);
            return View(_mapper.Map<NewDto>(news));
        }
        [HttpPost]
        public async Task<IActionResult> Update(NewDto newDto)
        {
            if(ModelState.IsValid)
            {
                await _services.UpdateAsync(_mapper.Map<New>(newDto));
                return RedirectToAction(nameof(Index));
            }
            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name", newDto.CategoryId);
            return View(newDto);
        }

        public async Task<IActionResult> Remove(int id)
        {
            var news = await _services.GetByIdAsync(id);
            await _services.RemoveAsync(news);
            return RedirectToAction(nameof(Index));
        }
    }
}
