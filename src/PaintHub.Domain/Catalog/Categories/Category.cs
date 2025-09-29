using PosterHub.Domain.Content;
using PosterHub.Domain.Shared;
using PosterHub.Domain.Shared.Catalog.Category;

namespace PosterHub.Domain.Catalog.Categories
{
    public class Category : BaseEntity<int>, ITreeNode
    {
        #region ITreeNode 

        public int? ParentCategoryId { get; set; }

        public Category Parent {  get; set; }

        public ICollection<Category> Children { get; set; }

        public string TreePath { get; set; }

        public IEnumerable<ITreeNode> GetChildNodes()
        {
            throw new NotImplementedException();
        }

        public ITreeNode GetParentNode()
        {
            throw new NotImplementedException();
        }

        #endregion

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

        public Category(string name, string fullName, string description)
        {
            SetName(name);
            FullName = fullName;
            Description = description;

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

        internal Category SetTreePath(string treePath)
        {
            if (string.IsNullOrWhiteSpace(treePath))
            {
                throw new ArgumentNullException(message: PosterHubErrorCodes.TreePathConNotBeNullOrEmpty, paramName: nameof(treePath));
            }

            TreePath = treePath;

            return this;
        }
        
    }
}
