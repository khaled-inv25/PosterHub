using Microsoft.AspNetCore.Mvc;
using PosterHub.Admin.Application.Contract;
using PosterHub.Admin.Application.Contract.Users.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterHub.Presentation.Controllers
{

    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IServiceAdminManager _service;

        public TokenController(IServiceAdminManager service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Refresh([FromBody] TokenDto model)
        {
            var tokenDtoToReturn = await _service.Authentication.RefreshTokenAsync(model);

            return Ok(tokenDtoToReturn);
        }
    }
}
