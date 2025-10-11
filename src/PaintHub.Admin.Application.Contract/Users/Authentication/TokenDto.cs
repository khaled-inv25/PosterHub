using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterHub.Admin.Application.Contract.Users.Authentication
{
    public record TokenDto(string AccessToken, string RefreshToken);
}
