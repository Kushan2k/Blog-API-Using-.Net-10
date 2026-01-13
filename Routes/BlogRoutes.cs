

namespace learn.Routes;

public static class BlogRoutes
{

    public static void RegisterBlogRoutes(this WebApplication app)
    {

        var blogGroup = app.MapGroup("/api/blogs");
        blogGroup.MapGet("/", () => "Get all blogs");
        blogGroup.MapGet("/{id}", (int id) => $"Get blog with ID {id}");
        blogGroup.MapPost("/", () => "Create a new blog");
        blogGroup.MapPut("/{id}", (int id) => $"Update blog with ID {id}");
        blogGroup.MapDelete("/{id}", (int id) => $"Delete blog with ID {id}");
    }

}
