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
            string treePath,
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
            if(parentCategoryId.HasValue)
            {
                var parentCategory = await _categoryRepository.FindByIdAsync(parentCategoryId.Value, false) ??
                    throw new CategoryNotFoundException(parentCategoryId.Value);

                treePath = parentCategory.TreePath;
            }

            var createdCategory = new Category(name, fullName, description);
            createdCategory.SetTreePath(treePath);

            return createdCategory;
        }
    }
}
