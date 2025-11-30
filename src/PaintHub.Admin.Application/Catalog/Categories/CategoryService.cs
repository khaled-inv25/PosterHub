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

        public async Task<IEnumerable<CategoryInListDto>> GetCategoriesAsync(bool truckChanges)
        {
            var categories = await _repositoryManager.Category.FindAllAsync(truckChanges);

            return categories.Select(c => new CategoryInListDto(
                c.Id,
                c.Name,
                c.TreePath,
                c.Published,
                c.ShowOnMenu,
                c.ShowOnHomePage
                )).ToList();
        }

        public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto input)
        {
            var category = await _domainManager.Category.CreateCategoryAsync(
                input.ParentCategoryId,
                input.Name,
                input.Description);

            category.Publish(input.Published);
            category.ShouOnMenu(input.ShowOnMenu);
            category.ShowOnHome(input.ShowOnHomePage);

            await _repositoryManager.Category.CreateAsync(category);
            _repositoryManager.Save();

            category.UpdateTreePath();
            _repositoryManager.Save();

            return new CategoryDto(
                category.Id,
                category.Name,
                category.Description,
                category.ParentCategoryId,
                category.TreePath,
                category.BadgeText,
                category.BadegStyle,
                category.MetaTitle,
                category.MetaDescription,
                category.PictureId,
                category.ShowOnMenu,
                category.ShowOnHomePage,
                category.SubjectToAcl,
                category.Published
            );
        }

        public void UpdateCategory(int id, UpdateCategoryDto input)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCategoryParent()
        {
            throw new NotImplementedException();
        }
    }
}
