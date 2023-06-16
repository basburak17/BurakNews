using BurakNews.API.Filters;
using BurakNews.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BurakNews.API.Controllers
{
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetSingleCategoryByIdWithNews(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetSingleCategoryByIdWithNews(categoryId));
        }
    }
}
