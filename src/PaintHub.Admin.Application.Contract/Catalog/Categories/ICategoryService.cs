namespace PosterHub.Admin.Application.Contract.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryInListDto>> GetCategoriesAsync(bool truckChanges);

        Task<CategoryWithIdDto> GetCategoryById(int id, bool trackChanges);

        Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto input);

        void UpdateCategory(int id, UpdateCategoryDto input);
    }
}
