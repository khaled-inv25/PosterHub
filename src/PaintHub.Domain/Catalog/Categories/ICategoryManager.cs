using PosterHub.Domain.Shared.Catalog.Category;

namespace PosterHub.Domain.Catalog.Categories
{
    public interface ICategoryManager
    {
        Task<Category> CreateCategory(
            int? ParentCategoryId,
            string TreePath,
            string Name,
            string FullName,
            string Description,
            string BadgeText,
            BadgeStyle BadegStyle,
            string MetaTitle,
            string MetaDescription,
            Guid? MediaFiledId,
            bool ShowOnMenu,
            bool ShowOnHomePage,
            bool SubjectToAcl,
            bool Published);
    }
}
