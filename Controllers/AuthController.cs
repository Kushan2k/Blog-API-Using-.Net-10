using learn.Dtos.User;
using learn.Services.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace learn.Controllers;


[ApiController]
[Route("api/auth")]
public class AuthController(IAuthService authService) : ControllerBase
{

    private readonly IAuthService _authService = authService;

  [HttpGet("login")]
    public bool Login()
    {
        return _authService.ValidateUser("kushan", "password");
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserCreateDto userCreateDto)
    {
        if (!userCreateDto.Password.Equals(userCreateDto.ConfirmPassword))
        {
            return BadRequest(new { message = "Password and Confirm Password do not match" });
        }
        var user = await _authService.CreateUser(userCreateDto);
        return Ok(new { message = "User created successfully", data = user });
    }
}
