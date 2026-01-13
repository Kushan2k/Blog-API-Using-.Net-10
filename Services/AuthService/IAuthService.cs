namespace learn.Services.AuthService;

public interface IAuthService
{

    bool ValidateUser(string username, string password);
}