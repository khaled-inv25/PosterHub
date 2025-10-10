using PosterHub.Admin.Application.Contract.Catalog.Categories;
using PosterHub.Admin.Application.Contract.Users.Authentication;

namespace PosterHub.Admin.Application.Contract
{
    public interface IServiceAdminManager
    {
        ICategoryService Category { get; }
        IAuthenticationService Authentication { get; }
    }
}
