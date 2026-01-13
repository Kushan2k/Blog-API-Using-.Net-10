namespace learn.Routes;


public static class AuthRoutes
{

    public static void RegisterAuthRoutes(this WebApplication app)
    {

        var group = app.MapGroup("/api/auth");

        group.MapPost("/register", () => "Register Endpoint");
        group.MapPost("/login", () => "Login Endpoint");

    }
}