namespace PosterHub.Domain.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(string? message = null) : base(message)
        {
        }
    }
}
