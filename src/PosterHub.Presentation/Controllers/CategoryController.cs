using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PosterHub.Admin.Application.Contract;
using PosterHub.Admin.Application.Contract.Catalog.Categories;

namespace PosterHub.Presentation.Controllers
{
    [Route("api/admin/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceAdminManager _serviceManager;

        public CategoryController(IServiceAdminManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _serviceManager.Category.GetCategoriesAsync(false));
        }

        [HttpGet("{id:int}", Name = "CategoryById")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            return Ok(await _serviceManager.Category.GetCategoryById(id, false));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto model)
        {
            if (model == null)
            {
                return BadRequest(ModelState);
            }

            var createdCategory = await _serviceManager.Category.CreateCategoryAsync(model);

            return CreatedAtRoute("CategoryById", new { id = createdCategory.Id }, createdCategory);
        }
    }
}
