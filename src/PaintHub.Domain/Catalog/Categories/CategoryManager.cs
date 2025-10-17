using Microsoft.EntityFrameworkCore;
using PosterHub.Domain.Exceptions;
using PosterHub.Domain.Shared.Catalog.Category;

namespace PosterHub.Domain.Catalog.Categories
{
    public class CategoryManager : ICategoryManager
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> CreateCategory(
            int? parentCategoryId,
            string name,
            string fullName,
            string description,
            string badgeText,
            BadgeStyle badegStyle,
            string metaTitle,
            string metaDescription,
            Guid? mediaFiledId,
            bool showOnMenu,
            bool showOnHomePage,
            bool subjectToAcl,
            bool published)
        {
            string parentTreePath = "";

            if(parentCategoryId.HasValue)
            {
                var parentCategory = _categoryRepository.GetQueryable(parentCategoryId.Value, trackChanges: false);

                parentTreePath = await parentCategory.Select(c => c.TreePath).SingleAsync();
            }

            var createdCategory = new Category(name, fullName, description, parentCategoryId);
            createdCategory.SetInternalTreePath(parentTreePath);

            return createdCategory;
        }
    }
}
