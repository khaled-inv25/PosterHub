namespace PosterHub.Admin.Application.Contract.Catalog.Categories
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryInListDto>> GetCategoriesAsync(bool truckChanges);

        Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto input);

        void UpdateCategory(int id, UpdateCategoryDto input);

        Task<string> GetCategoryParent();
    }
}
