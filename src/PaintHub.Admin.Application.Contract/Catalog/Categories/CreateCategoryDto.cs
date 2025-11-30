using PosterHub.Domain.Shared.Catalog.Category;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PosterHub.Admin.Application.Contract.Catalog.Categories
{
    public class CreateCategoryDto
    {
        [AllowNull]
        public int? ParentCategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [AllowNull]
        public string? Description { get; set; }

        [AllowNull]
        public string? BadgeText { get; set; }

        public BadgeStyle BadegStyle { get; set; }

        [AllowNull]
        public string? MetaTitle { get; set; }

        [AllowNull]
        public string? MetaDescription { get; set; }

        [AllowNull]
        public Guid? PictureId { get; set; }

        [Required]
        public bool ShowOnMenu { get; set; }

        [Required]
        public bool ShowOnHomePage { get; set; }

        [Required]
        public bool SubjectToAcl { get; set; }

        [Required]
        public bool Published { get; set; }

    }
}
