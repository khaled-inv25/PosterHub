using PosterHub.Domain.Shared.Catalog.Category;

namespace PosterHub.Domain.Catalog.Categories
{
    public class CategoryManager : ICategoryManager
    {
        public Category CreateCategory(
            int? parentCategoryId,
            string treePath,
            string name,
            string fullName,
            string description,
            string badgeText,
            BadgeStyle badegStyle,
            string metaTitle,
            string metaDescription,
            Guid? mediaFiledId,
            bool showOnMenu,
            bool showOnHomePage,
            bool subjectToAcl,
            bool published)
        {
            if( parentCategoryId.HasValue)
            {
                treePath = $"/{parentCategoryId.Value}/";
            }
            else
            {
                treePath = "/root/";
            }

            name = name.ToLower();

            var createdCategory = new Category(name, fullName, description);
            createdCategory.SetTreePath(treePath);

            return createdCategory;
        }
    }
}
