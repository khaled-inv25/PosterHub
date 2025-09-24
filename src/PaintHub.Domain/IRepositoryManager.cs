using PosterHub.Domain.Catalog.Categories;

namespace PosterHub.Domain
{
    public interface IRepositoryManager
    {
        ICategoryRepository Category { get; }
        void Save();
    }
}
