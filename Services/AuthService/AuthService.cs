
using learn.Data;
using learn.Dtos.User;
using learn.Models;
using learn.Services.JwtService;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ILogger = learn.Factories.Logger.ILogger;
namespace learn.Services.AuthService;


public class AuthService(ApplicationDbContext _context, ILogger _logger, IJwtService _jwtService) : IAuthService
{
    public bool ValidateUser(string username, string password)
    {
        throw new NotImplementedException();
    }


    public async Task<IActionResult> CreateUser(UserCreateDto userReq)
    {

        try
        {
            var user = new User
            {
                Email = userReq.Email,
                FullName = userReq.FullName,
                PasswordHash = ""

            };

            var foundUser = await _context.Users.AnyAsync(user => user.Email.Equals(userReq.Email));

            if (foundUser)
            {
                return new ConflictObjectResult(new { message = "User with this email already exists" });
            }

            byte[] salt = new byte[128 / 8];
            string hashed = BCrypt.Net.BCrypt.EnhancedHashPassword(userReq.Password);

            user.PasswordHash = hashed;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();


            _logger.LogInfo($"[{DateTime.Now}] -- User created successfully with email: {user.Email}");

            return new CreatedResult("", new { message = "User created successfully", data = new UserDto(user.Id, user.Email, user.FullName) });


        }
        catch (Exception ex)
        {
            Console.WriteLine($"==============Error creating user: {ex.Message}");
            _logger.LogError($"[{DateTime.Now}] -- Error creating user: {ex.Message}");
            return new StatusCodeResult(500);
        }
    }

    public async Task<IActionResult> LoginUser(UserLoginDto userLoginDto)
    {

        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(userLoginDto.Email));

            if (user == null)
            {
                return new NotFoundObjectResult(new { message = "User not found" });
            }
            bool verified = BCrypt.Net.BCrypt.EnhancedVerify(userLoginDto.Password, user.PasswordHash);
            if (!verified)
            {
                return new UnauthorizedObjectResult(new { message = "Invalid credentials" });
            }
            _logger.LogInfo($"[{DateTime.Now}] -- User logged in successfully with email: {user.Email}");

            string token = _jwtService.GenerateToken(user);

            return new OkObjectResult(new { message = "Login successful", token = token });


        }
        catch (Exception ex)
        {
            _logger.LogError($"[{DateTime.Now}] -- Error logging in user: {ex.Message}");
            return new StatusCodeResult(500);
        }
    }
}
