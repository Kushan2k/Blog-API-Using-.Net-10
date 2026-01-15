using learn.Factories.Logger;
using learn.Services.AuthService;
using learn.Services.BlogService;
using ILogger = learn.Factories.Logger.ILogger;

namespace learn.Extentions;


public static class AppExtentions
{

    public static void RegisterServices(this WebApplicationBuilder builder)
    {

        builder.Services.AddScoped<IBlogService, BlogService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
    }

    public static void AddLogger(this WebApplicationBuilder builder)
    {
        ILogger logger = LocalLoggerFactory.CreateLogger(LoggerTypes.File);
        builder.Services.AddSingleton<ILogger>(logger);

    }
}
