using PosterHub.Domain.Shared;

namespace PosterHub.Domain.Exceptions
{
    public sealed class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(int id) 
            : base(PosterHubErrorCodes.CategoryNotFound + id)
        {
        }
    }
}
