using PosterHub.Domain.Shared.Catalog.Category;
using System.Diagnostics.CodeAnalysis;

namespace PosterHub.Admin.Application.Contract.Catalog.Categories
{
    public class CreateCategoryDto
    {
        public int? ParentCategoryId { get; set; }

        [AllowNull]
        public string? TreePath { get; set; }

        public string Name { get; set; }

        [AllowNull]
        public string? FullName { get; set; }

        [AllowNull]
        public string? Description { get; set; }

        [AllowNull]
        public string? BadgeText { get; set; }

        public BadgeStyle BadegStyle { get; set; }

        [AllowNull]
        public string? MetaTitle { get; set; }

        [AllowNull]
        public string? MetaDescription { get; set; }

        public Guid? MediaFiledId { get; set; }

        public bool ShowOnMenu { get; set; }

        public bool ShowOnHomePage { get; set; }

        public bool SubjectToAcl { get; set; }

        public bool Published { get; set; }

    }
}
