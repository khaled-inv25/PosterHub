using PosterHub.Domain.Content;
using PosterHub.Domain.Shared;
using PosterHub.Domain.Shared.Catalog.Category;

namespace PosterHub.Domain.Catalog.Categories
{
    public class Category : BaseEntity<int>
    {
        public int? ParentCategoryId { get; set; }

        public Category Parent {  get; set; }

        public string TreePath { get; private set; }

        public ICollection<Category> Children { get; set; }

        public string Name { get; private set; }

        public string FullName { get; set; }

        public string Description { get; set; }

        public string BadgeText { get; set; }

        public BadgeStyle BadegStyle { get; set; }

        public string MetaTitle { get; set; }

        public string MetaDescription { get; set; }

        public Guid? MediaFiledId { get; set; }

        public MediaFile? MediaFile { get; set; }

        public bool ShowOnMenu { get; set; }

        public bool ShowOnHomePage { get; set; }

        public bool SubjectToAcl { get; set; }

        public bool Published { get; set; }

        public Category(string name, string fullName, string description, int? parentCategoryId)
        {
            SetName(name);
            FullName = fullName;
            Description = description;

            ParentCategoryId = parentCategoryId;

            ShowOnMenu = true;
            ShowOnHomePage = true;
            SubjectToAcl = false;
            Published = true;
        }

        internal Category SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(message: PosterHubErrorCodes.CategoryNameConNotBeNullOrEmpty, paramName: nameof(name));
            }

            Name = name.ToLower();

            return this;
        }

        internal Category SetInternalTreePath(string treePath)
        {
            if (!ParentCategoryId.HasValue)
            {
                TreePath = string.Empty;
                return this;
            }

            TreePath = treePath;

            return this;
        }
        
        public Category UpdateTreePath()
        {
            if (string.IsNullOrEmpty(TreePath))
            {
                TreePath = $"/{Id}/";
                return this;
            }

            TreePath += $"{Id}/";

            return this;
        }

    }
}
