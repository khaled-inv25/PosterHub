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

        [HttpGet("list")]
        public async Task<IActionResult> GetCategories(bool trackChanges)
        {
            return Ok(await _serviceManager.Category.GetCategoriesAsync(trackChanges));
        }

        [HttpGet("{id:int}", Name = "CategoryById")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            //return Ok(await _serviceManager.Category.GetCategoryById(id, false));
            return Ok();
        }

        //[Authorize(Roles = "Administrator")]
        [HttpPost("create")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto model)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var createdCategory = await _serviceManager.Category.CreateCategoryAsync(model);

            return CreatedAtRoute("CategoryById", new { id = createdCategory.Id }, createdCategory);
        }
    }
}
