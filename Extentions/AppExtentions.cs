using learn.Factories.Logger;
using learn.Services.AuthService;
using learn.Services.BlogService;
using learn.Services.JwtService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ILogger = learn.Factories.Logger.ILogger;

namespace learn.Extentions;


public static class AppExtentions
{

    public static void RegisterServices(this WebApplicationBuilder builder)
    {

        builder.Services.AddScoped<IBlogService, BlogService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IJwtService, JwtService>();
    }

    public static void AddLogger(this WebApplicationBuilder builder)
    {
        ILogger logger = LocalLoggerFactory.CreateLogger(LoggerTypes.File);
        builder.Services.AddSingleton<ILogger>(logger);

    }


    public static void AddAuthenticationJwt(this WebApplicationBuilder builder)
    {
        // JWT Authentication configuration would go here

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
        });
    }
}
