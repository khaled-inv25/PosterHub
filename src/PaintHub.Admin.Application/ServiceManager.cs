using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using PosterHub.Admin.Application.Catalog.Categories;
using PosterHub.Admin.Application.Contract;
using PosterHub.Admin.Application.Contract.Catalog.Categories;
using PosterHub.Admin.Application.Contract.Users.Authentication;
using PosterHub.Admin.Application.Users.Authentication;
using PosterHub.Domain;
using PosterHub.Domain.Users;
using PosterHub.Logger.Contract;

namespace PosterHub.Admin.Application
{
    public sealed class ServiceManager : IServiceAdminManager
    {
        private readonly Lazy<ICategoryService> _categoryService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(
            IRepositoryManager repositoryManager, 
            IDomainManager domainManager, 
            UserManager<User> userManager, 
            ILoggerManager logger, 
            IConfiguration configuration
            )
        {
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager, domainManager));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(userManager, logger, configuration));
        }

        public ICategoryService Category => _categoryService.Value;

        public IAuthenticationService Authentication => _authenticationService.Value;
    }
}
