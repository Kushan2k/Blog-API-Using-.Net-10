namespace learn.Services.JwtService;

public interface IJwtService
{

    string GenerateToken(int userId, string username);
}