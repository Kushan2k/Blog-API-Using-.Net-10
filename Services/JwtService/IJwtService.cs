using learn.Models;

namespace learn.Services.JwtService;

public interface IJwtService
{

    string GenerateToken(User user);
}