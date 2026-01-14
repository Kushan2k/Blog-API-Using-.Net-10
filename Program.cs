using learn.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();
builder.Services.AddControllers();

var connString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddMySql<ApplicationDbContext>(connString, ServerVersion.AutoDetect(connString));
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.MigrateDB();

app.Run();
