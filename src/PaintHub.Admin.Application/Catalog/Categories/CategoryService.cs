using PosterHub.Admin.Application.Contract.Catalog.Categories;
using PosterHub.Domain;
using PosterHub.Domain.Exceptions;

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
                c.Name,
                c.FullName,
                c.Published,
                c.ShowOnMenu,
                c.ShowOnHomePage
                )).ToList();
        }

        public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto input)
        {
            var category = await _domainManager.Category.CreateCategory(
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

            await _repositoryManager.Category.CreateCategoryAsync(category);
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
            );
        }

        public async Task<CategoryWithIdDto> GetCategoryById(int id, bool trackChanges)
        {
            var category = await _repositoryManager.Category.FindByIdAsync(id, trackChanges) 
                ?? throw new CategoryNotFoundException(id);

            return new CategoryWithIdDto(
                category.Id,
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
            );
        }

        public void UpdateCategory(int id, UpdateCategoryDto input)
        {
            throw new NotImplementedException();
        }
    }
}
