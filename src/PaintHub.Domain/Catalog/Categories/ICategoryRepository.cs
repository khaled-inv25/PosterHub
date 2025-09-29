namespace PosterHub.Domain.Catalog.Categories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories(bool truckChanges);

        Category CreateCategory(Category input);

        Category? GetCategoryById(int id, bool trackChanges);

        Category? GetParent(int parentId);
    }
}
