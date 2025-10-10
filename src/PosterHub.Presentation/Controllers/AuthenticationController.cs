using Microsoft.AspNetCore.Mvc;
using PosterHub.Admin.Application.Contract;
using PosterHub.Admin.Application.Contract.Users;
using PosterHub.Admin.Application.Contract.Users.Authentication;

namespace PosterHub.Presentation.Controllers
{

    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceAdminManager _services;

        public AuthenticationController(IServiceAdminManager serviceAdminManager)
        {
            _services = serviceAdminManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserAuthintecationDto model)
        {
           if (!await _services.Authentication.ValidateUser(model))
            {
                return Unauthorized();
            }

            return Ok(new { Token = await _services.Authentication.CreateToken() } );
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(RegisterUserDto model)
        {
            var result = await _services.Authentication.RegisterUser(model);

            return Ok(result);
        }

    }
}
