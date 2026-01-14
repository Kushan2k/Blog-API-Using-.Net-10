using learn.Data;
using Microsoft.EntityFrameworkCore;

public static class DataExtensions
{

    public static void MigrateDB(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider
                                .GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();
    }
}