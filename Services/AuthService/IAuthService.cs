using learn.Dtos.User;

namespace learn.Services.AuthService;

public interface IAuthService
{

    bool ValidateUser(string username, string password);
    Task<UserDto> CreateUser(UserCreateDto userReq);
}