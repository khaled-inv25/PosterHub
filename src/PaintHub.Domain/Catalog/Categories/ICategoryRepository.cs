namespace PosterHub.Domain.Catalog.Categories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> FindAllAsync(bool truckChanges);

        Task<Category> CreateCategoryAsync(Category input);

        Task<Category?> FindByIdAsync(int id, bool trackChanges);

        Category? GetParent(int parentId);
    }
}
