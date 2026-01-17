using learn.Data;
using learn.Extentions;
using learn.Middlewares;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();

builder.RegisterServices();
builder.AddLogger();
builder.AddAuthenticationJwt();

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();


var connString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddMySql<ApplicationDbContext>(connString, ServerVersion.AutoDetect(connString));
var app = builder.Build();

app.UseMiddleware<UserMiddleware>();

app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.MigrateDB();

app.Run();
