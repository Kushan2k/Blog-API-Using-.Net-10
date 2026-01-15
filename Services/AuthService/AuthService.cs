using System.Security.Cryptography;
using learn.Data;
using learn.Dtos.User;
using learn.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;

namespace learn.Services.AuthService;


public class AuthService(ApplicationDbContext _context) : IAuthService
{
    public bool ValidateUser(string username, string password)
    {
        throw new NotImplementedException();
    }


    public async Task<UserDto> CreateUser(UserCreateDto userReq)
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
                throw new Exception("User with this email already exists");
            }

            byte[] salt = [128 / 10];
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

            return new UserDto(user.Id, user.Email, user.FullName);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"==============Error creating user: {ex.Message}");
            throw ;
        }
    }
}
