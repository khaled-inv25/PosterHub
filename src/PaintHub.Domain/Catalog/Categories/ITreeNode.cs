namespace PosterHub.Domain.Catalog.Categories
{
    public interface ITreeNode
    {
        public int? ParentCategoryId { get; set; }

        public string TreePath { get; set; }

        public ITreeNode GetParentNode();

        public IEnumerable<ITreeNode> GetChildNodes();

        //public IQueryable<ITreeNode>
    }
}
