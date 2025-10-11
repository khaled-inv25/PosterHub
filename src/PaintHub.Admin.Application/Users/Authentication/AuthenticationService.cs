using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PosterHub.Admin.Application.Contract.Users;
using PosterHub.Admin.Application.Contract.Users.Authentication;
using PosterHub.Domain.Shared;
using PosterHub.Domain.Users;
using PosterHub.Logger.Contract;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PosterHub.Admin.Application.Users.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IConfiguration _configuration;
        private User? _user;

        public AuthenticationService(
           UserManager<User> userManager, ILoggerManager loggerManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _loggerManager = loggerManager;
            _configuration = configuration;
        }

        #region Token
        public async Task<TokenDto> CreateToken(bool populateExp)
        {
            var signinCredentials = GetSigningCredentials();
            var claims = await GetClaimsAsync();
            var tokenOptions = GenerateTokenOptions(signinCredentials, claims);

            var refreshToken = GenerateRefreshToken();

            _user.RefreshToken = refreshToken;
            if (populateExp)
            {
                _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            }

            await _userManager.UpdateAsync(_user);
            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new TokenDto(accessToken, refreshToken);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaimsAsync()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials credentials, List<Claim> claims)
        {

            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenOption = new JwtSecurityToken
                (
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                signingCredentials: credentials,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"]))
                );

            return tokenOption;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using var rang = RandomNumberGenerator.Create();
            rang.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"))),
                ValidateLifetime = true,
                ValidIssuer = jwtSettings["validIssuer"],
                ValidAudience = jwtSettings["validAudience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || 
                jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException(PosterHubErrorCodes.InvalidToken);
            }

            return principal;
        }

        #endregion

        public async Task<object> RegisterUser(RegisterUserDto input)
        {
            var user = new User()
            {
                UserName = input.UserName,
                PhoneNumber = input.PhoneNumber,
                Email = input.Email,
            };

            var result = await _userManager.CreateAsync(user, input.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRolesAsync(user, input.Roles);
            }

            return result;
        }

        public async Task<bool> ValidateUser(UserAuthintecationDto input)
        {
            _user = await _userManager.FindByNameAsync(input.Username);

            var result = (_user != null && await _userManager.CheckPasswordAsync(_user, input.Password));

            if (!result)
            {
                _loggerManager.LogWarn($"{nameof(ValidateUser)}: {PosterHubErrorCodes.WrongUsernameOrPassword}");
            }

            return result;
        }

    }
}
