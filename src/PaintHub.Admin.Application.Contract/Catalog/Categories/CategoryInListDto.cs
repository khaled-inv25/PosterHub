namespace PosterHub.Admin.Application.Contract.Catalog.Categories
{
    public record CategoryInListDto(
        int Id,
        string Name, 
        string FullName,
        string TreePath,
        bool Published,
        bool ShowOnMenu,
        bool ShowOnHomePage
        );
}
