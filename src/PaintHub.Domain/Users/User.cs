using Microsoft.AspNetCore.Identity;

namespace PosterHub.Domain.Users
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }


    }
}
