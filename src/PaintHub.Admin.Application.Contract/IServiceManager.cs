using PosterHub.Admin.Application.Contract.Catalog.Categories;

namespace PosterHub.Admin.Application.Contract
{
    public interface IServiceManager
    {
        ICategoryService Category { get; }
    }
}
