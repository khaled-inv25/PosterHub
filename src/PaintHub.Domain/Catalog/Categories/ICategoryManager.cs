using PosterHub.Domain.Shared.Catalog.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterHub.Domain.Catalog.Categories
{
    public interface ICategoryManager
    {
        Category CreateCategory(
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
