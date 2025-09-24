namespace PosterHub.Domain.Catalog.Categories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories(bool truckChanges);

        Category CreateCategory(Category input);
    }
}
