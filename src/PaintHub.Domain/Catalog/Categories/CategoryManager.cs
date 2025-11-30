using Microsoft.EntityFrameworkCore;
using PosterHub.Domain.Exceptions;
using PosterHub.Domain.Shared;

namespace PosterHub.Domain.Catalog.Categories
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> CreateCategoryAsync(
            int? parentCategoryId,
            string name,
            string description)
        {
            // To prevent duplicate.
            name = name.Trim().ToLower();
            if (await _categoryRepository.AnyAsync(c => c.Name.Equals(name)))
            {
                throw new BusinessException(PosterHubErrorCodes.CategoryExists);
            }

            string treePath = string.Empty;

            if (parentCategoryId.HasValue)
            {
                var isExists = await _categoryRepository.AnyAsync(c => c.Id == parentCategoryId.Value);
                if (!isExists )
                {
                    throw new CategoryNotFoundException(parentCategoryId.Value);
                }

                var parentCategoryQuerable = _categoryRepository
                        .FindByCondition(c => c.Id.Equals(parentCategoryId.Value), trackChanges: false);

                treePath = await parentCategoryQuerable.Select(c => c.TreePath).SingleAsync();
            }

            var createdCategory = new Category(name, description, parentCategoryId);
            createdCategory.SetTreePath(treePath);

            return createdCategory;
        }
    }
}
