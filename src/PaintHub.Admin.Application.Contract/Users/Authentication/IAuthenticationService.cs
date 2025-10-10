namespace PosterHub.Admin.Application.Contract.Users.Authentication
{
    public interface IAuthenticationService
    {
        Task<object> RegisterUser(RegisterUserDto input);
        Task<bool> ValidateUser(UserAuthintecationDto input);
        Task<string> CreateToken();
    }
}
