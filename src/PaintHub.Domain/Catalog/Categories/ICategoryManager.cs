using PosterHub.Domain.Shared.Catalog.Category;

namespace PosterHub.Domain.Catalog.Categories
{
    public interface ICategoryManager
    {
        Task<Category> CreateCategoryAsync(
            int? parentCategoryId,
            string name,
            string description);
    }
}
