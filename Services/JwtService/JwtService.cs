using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using learn.Models;
using Microsoft.IdentityModel.Tokens;

namespace learn.Services.JwtService;


public class JwtService(IConfiguration _configuration) : IJwtService
{
    public string GenerateToken(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("userId", user.Id.ToString())
        };

        // 2. Create key and credentials
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var _issuer = _configuration["Jwt:Issuer"];
        var _audience = _configuration["Jwt:Audience"];
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // 3. Create token
        var token = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: creds
        );

        // 4. Return token string
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}