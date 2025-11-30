using PosterHub.Domain.Shared;

namespace PosterHub.Domain.Catalog.Categories
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        Task<IEnumerable<Category>> FindAllAsync(bool truckChanges);

        Category? GetParent(int parentId);
    }
}
