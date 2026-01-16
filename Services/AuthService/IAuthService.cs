using learn.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace learn.Services.AuthService;

public interface IAuthService
{

    bool ValidateUser(string username, string password);
    Task<IActionResult> CreateUser(UserCreateDto userReq);
    Task<IActionResult> LoginUser(UserLoginDto userLoginDto);
}
