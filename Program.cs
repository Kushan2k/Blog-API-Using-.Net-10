using learn.Routes;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidation();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.RegisterBlogRoutes();

app.Run();
