namespace PosterHub.Admin.Application.Contract.Catalog.Categories
{
    public interface ICategoryService
    {
        IEnumerable<CategoryInListDto> GetCategories(bool truckChanges);

        CategoryWithIdDto GetCategoryById(int id, bool trackChanges);

        CategoryDto CreateCategory(CreateCategoryDto input);

        void UpdateCategory(int id, UpdateCategoryDto input);

        void UpdateCategory(int id);
    }
}
