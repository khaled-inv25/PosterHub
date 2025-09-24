namespace PosterHub.Admin.Application.Contract.Catalog.Categories
{
    public interface ICategoryService
    {
        IEnumerable<CategoryInListDto> GetCategories(bool truckChanges);

        CategoryDto CreateCategory(CreateCategoryDto input);
    }
}
