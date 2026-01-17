namespace learn.Middlewares;


public class UserMiddleware
{
    private readonly RequestDelegate _next;

    public UserMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
      // Middleware logic can be added here
      if (context.User.Identity?.IsAuthenticated==true)
      {
        var userid = context.User.FindFirst("userId")?.Value;

        context.Items["UserId"] = userid;
      }

          await _next(context);
    }
}
