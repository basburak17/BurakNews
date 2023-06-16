using AutoMapper;
using BurakNews.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace BurakNews.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _services;
        private readonly INewService _newsService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService services, INewService newsService, IMapper mapper)
        {
            _services = services;
            _newsService = newsService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _services.GetAllAsync());
        }
    }
}
