namespace PosterHub.Admin.Application.Contract.Users.Authentication
{
    public interface IAuthenticationService
    {
        Task<object> RegisterUserAsync(RegisterUserDto input);
        Task<bool> ValidateUserAsync(UserAuthintecationDto input);
        Task<TokenDto> CreateTokenAsync(bool populateExp);
        Task<TokenDto> RefreshTokenAsync(TokenDto tokenDto);

    }
}
