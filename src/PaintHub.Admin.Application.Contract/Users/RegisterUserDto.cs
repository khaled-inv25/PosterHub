using PosterHub.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace PosterHub.Admin.Application.Contract.Users
{
    public record RegisterUserDto
    {
        public string FirstName { get; init; }

        public string LastName { get; init; }

        [Required(ErrorMessage = PosterHubErrorCodes.UsernameRequired)]
        public string UserName { get; init; }

        [Required(ErrorMessage = PosterHubErrorCodes.PasswordRequired)]
        public string Password { get; init; }

        public string Email { get; init; }

        public string PhoneNumber { get; init; }

        public ICollection<string> Roles { get; init; }

    }
}
