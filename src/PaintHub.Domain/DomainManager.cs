using PosterHub.Domain.Catalog.Categories;

namespace PosterHub.Domain
{
    public class DomainManager : IDomainManager
    {
        private readonly Lazy<ICategoryManager> _categoryManager;

        public DomainManager(IRepositoryManager repositoryManager)
        {
            _categoryManager = new Lazy<ICategoryManager>(() => new CategoryManager(repositoryManager.Category));
        }

        public ICategoryManager Category => _categoryManager.Value;
    }
}
