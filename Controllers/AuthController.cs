using learn.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace learn.Controllers;

public class AuthController(AuthService _authService) : ControllerBase
{

    private readonly IAuthService _authService = _authService;


    [HttpGet("login")]
    public bool Login()
    {
        return _authService.ValidateUser("kushan", "password");
    }
}