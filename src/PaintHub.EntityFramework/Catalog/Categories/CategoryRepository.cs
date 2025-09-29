using PosterHub.Domain.Catalog.Categories;
using PosterHub.EntityFramework.AppDbContext;

namespace PosterHub.EntityFramework.Catalog.Categories
{
    public sealed class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(PosterHubDbContext posterHubDbContext) : base(posterHubDbContext)
        {
        }

        public IEnumerable<Category> GetCategories(bool truckChanges) =>
            FindAll(truckChanges)
                .OrderBy(c => c.Name)
                .ToList();

        public Category CreateCategory(Category input)
        {
            Create(input);

            return input;
        }

        public Category? GetCategoryById(int id, bool trackChanges)
        {
            return FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefault();
        }

        public Category? GetParent(int parentId)
        {
            return FindByCondition(c => c.ParentCategoryId.Equals(parentId), false).SingleOrDefault();
        }
    }
}
