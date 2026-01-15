
using learn.Data;
using learn.Dtos.User;
using learn.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ILogger = learn.Factories.Logger.ILogger;
namespace learn.Services.AuthService;


public class AuthService(ApplicationDbContext _context,ILogger _logger) : IAuthService
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
            string hashed = Convert.ToBase64String(
                KeyDerivation.Pbkdf2(
                    password: userReq.Password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8
                )
            );

            user.PasswordHash = hashed;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();


            _logger.LogInfo($"[{DateTime.Now}] -- User created successfully with email: {user.Email}");
            
            return new CreatedResult("", new { message = "User created successfully", data = new UserDto(user.Id, user.Email, user.FullName) } );
            
            
        }
        catch (Exception ex)
        {
            Console.WriteLine($"==============Error creating user: {ex.Message}");
            _logger.LogError($"[{DateTime.Now}] -- Error creating user: {ex.Message}");
            return new StatusCodeResult(500);
        }
    }
}
