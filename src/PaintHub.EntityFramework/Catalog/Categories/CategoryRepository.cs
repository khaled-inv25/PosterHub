using Microsoft.EntityFrameworkCore;
using PosterHub.Domain.Catalog.Categories;
using PosterHub.EntityFramework.AppDbContext;
using System.Linq.Expressions;

namespace PosterHub.EntityFramework.Catalog.Categories
{
    public sealed class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(PosterHubDbContext posterHubDbContext) : base(posterHubDbContext)
        {
        }

        public async Task<IEnumerable<Category>> FindAllAsync(bool truckChanges) =>
            await FindAll(truckChanges)
                .OrderBy(c => c.Name)
                .ToListAsync();

        public async Task<Category?> FindByIdAsync(int id, bool trackChanges)
        {
            return await FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public Category? GetParent(int parentId)
        {
            return FindByCondition(c => c.ParentCategoryId.Equals(parentId), false).SingleOrDefault();
        }
    }
}
