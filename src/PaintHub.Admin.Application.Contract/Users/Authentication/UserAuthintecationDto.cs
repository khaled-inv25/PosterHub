using PosterHub.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace PosterHub.Admin.Application.Contract.Users.Authentication
{
    public record UserAuthintecationDto
    {
        [Required(ErrorMessage = PosterHubErrorCodes.UsernameRequired)]
        public string Username { get; init; }

        [Required(ErrorMessage = PosterHubErrorCodes.PasswordRequired)]
        public string Password { get; init; }
    }
}
