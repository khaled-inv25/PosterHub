using PosterHub.Domain.Shared.Catalog.Category;

namespace PosterHub.Admin.Application.Contract.Catalog.Categories
{
    public record UpdateCategoryDto(
        string Name,
        string FullName,
        string Description,
        int? ParentCategoryId,
        string TreePath,
        string BadgeText,
        BadgeStyle BadegStyle,
        string MetaTitle,
        string MetaDescription,
        Guid? MediaFiledId,
        bool ShowOnMenu,
        bool ShowOnHomePage,
        bool SubjectToAcl,
        bool Published
    );
}
