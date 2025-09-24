using PosterHub.Domain;
using PosterHub.Domain.Catalog.Categories;
using PosterHub.EntityFramework.AppDbContext;
using PosterHub.EntityFramework.Catalog.Categories;

namespace PosterHub.EntityFramework
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly PosterHubDbContext _dbContext;

        private readonly Lazy<ICategoryRepository> _categoryRepository;

        public RepositoryManager(PosterHubDbContext posterHubDbContext)
        {
            _dbContext = posterHubDbContext;
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(posterHubDbContext));
        }

        public ICategoryRepository Category => _categoryRepository.Value;

        public void Save() => _dbContext.SaveChanges();
    }
}
