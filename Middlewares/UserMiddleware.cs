namespace learn.Middlewares;

using ILogger = learn.Factories.Logger.ILogger;


public class UserMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public UserMiddleware(RequestDelegate next, ILogger logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Middleware logic can be added here
        if (context.User.Identity?.IsAuthenticated == true)
        {
            try
            {
                var userid = context.User.FindFirst("userId")?.Value;

                context.Items["UserId"] = userid;
            }
            catch (System.Exception)
            {
                _logger.LogWarning("UserMiddleware: Unable to extract userId from token.");
                await _next(context);
            }
        }

        await _next(context);
    }
}
