using learn.Services.AuthService;
using learn.Services.BlogService;

namespace learn.Extentions;


public static class AppExtentions
{

    public static void RegisterServices(this WebApplicationBuilder builder)
    {

        builder.Services.AddScoped<IBlogService, BlogService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
    }
}