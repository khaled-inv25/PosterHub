using Microsoft.AspNetCore.Mvc;
using PosterHub.Admin.Application.Contract;
using PosterHub.Admin.Application.Contract.Catalog.Categories;

namespace PosterHub.Presentation.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CategoryController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(_serviceManager.CategoryService.GetCategories(false));
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CreateCategoryDto model)
        {
            return Ok(_serviceManager.CategoryService.CreateCategory(model));
        }
    }
}
