namespace PosterHub.Admin.Application.Contract.Catalog.Categories
{
    public record CategoryInListDto(
        string Name, 
        string FullName,
        string TreePath,
        bool Published,
        bool ShowOnMenu,
        bool ShowOnHomePage
        );
}
