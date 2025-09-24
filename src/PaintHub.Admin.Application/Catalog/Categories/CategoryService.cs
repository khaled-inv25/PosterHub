using PosterHub.Admin.Application.Contract.Catalog.Categories;
using PosterHub.Domain;

namespace PosterHub.Admin.Application.Catalog.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IDomainManager _domainManager;

        public CategoryService(IRepositoryManager repositoryManager, IDomainManager domainManager)
        {
            _repositoryManager = repositoryManager;
            _domainManager = domainManager;
        }

        public IEnumerable<CategoryInListDto> GetCategories(bool truckChanges)
        {
            var categories = _repositoryManager.Category.GetCategories(truckChanges);

            return categories.Select(c => new CategoryInListDto(
                c.Name,
                c.FullName,
                c.Published,
                c.ShowOnMenu,
                c.ShowOnHomePage
                )).ToList();
        }

        public CategoryDto CreateCategory(CreateCategoryDto input)
        {
            var category = _domainManager.CategoryManager.CreateCategory(
                input.ParentCategoryId,
                input.TreePath,
                input.Name,
                input.FullName,
                input.Description,
                input.BadgeText,
                input.BadegStyle,
                input.MetaTitle,
                input.MetaDescription,
                input.MediaFiledId,
                input.ShowOnMenu,
                input.ShowOnHomePage,
                input.SubjectToAcl,
                input.Published
                );

            _repositoryManager.Category.CreateCategory(category);
            _repositoryManager.Save();

            return new CategoryDto(
                category.Name,
                category.FullName,
                category.Description,
                category.ParentCategoryId,
                category.TreePath,
                category.BadgeText,
                category.BadegStyle,
                category.MetaTitle,
                category.MetaDescription,
                category.MediaFiledId,
                category.ShowOnMenu,
                category.ShowOnHomePage,
                category.SubjectToAcl,
                category.Published
            ); ;
        }
    }
}
