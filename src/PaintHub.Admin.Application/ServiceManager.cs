using PosterHub.Admin.Application.Catalog.Categories;
using PosterHub.Admin.Application.Contract;
using PosterHub.Admin.Application.Contract.Catalog.Categories;
using PosterHub.Domain;

namespace PosterHub.Admin.Application
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICategoryService> _categoryService;

        public ServiceManager(IRepositoryManager repositoryManager, IDomainManager domainManager)
        {
            _categoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager, domainManager));
        }

        public ICategoryService CategoryService => _categoryService.Value;
    }
}
