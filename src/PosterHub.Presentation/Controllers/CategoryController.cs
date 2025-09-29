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
            return Ok(_serviceManager.Category.GetCategories(false));
        }

        [HttpGet("{id:int}", Name = "CategoryById")]
        public IActionResult GetCategoryById(int id)
        {
            return Ok(_serviceManager.Category.GetCategoryById(id, false));
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CreateCategoryDto model)
        {
            if (model == null)
            {
                return BadRequest(ModelState);
            }

            var createdCategory = _serviceManager.Category.CreateCategory(model);

            return CreatedAtRoute("CategoryById", new { id = 1 }, createdCategory);
        }
    }
}
