using learn.Context;
using learn.Routes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();

builder.Services.AddMySql<ApplicationDbContext>(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 23)));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.RegisterAuthRoutes();
app.RegisterBlogRoutes();

app.Run();
