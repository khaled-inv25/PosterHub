using PosterHub.Domain.Catalog.Categories;

namespace PosterHub.Domain
{
    public interface IDomainManager
    {
        ICategoryManager Category { get; } 
    }
}
