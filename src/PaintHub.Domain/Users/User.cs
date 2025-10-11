using Microsoft.AspNetCore.Identity;

namespace PosterHub.Domain.Users
{
    public class User : IdentityUser
    {
        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
