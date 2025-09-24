using PosterHub.Domain.Catalog.Categories;

namespace PosterHub.Domain
{
    public class DomainManager : IDomainManager
    {
        private readonly Lazy<ICategoryManager> _categoryManager;

        public DomainManager()
        {
            _categoryManager = new Lazy<ICategoryManager>(() => new CategoryManager());
        }

        public ICategoryManager CategoryManager => _categoryManager.Value;
    }
}
