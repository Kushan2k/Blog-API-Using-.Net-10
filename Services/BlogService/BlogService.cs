using learn.Data;
using learn.Dtos.Blog;
using learn.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ILogger = learn.Factories.Logger.ILogger;

namespace learn.Services.BlogService;


public class BlogService(ApplicationDbContext _context,IHttpContextAccessor _httpContextAccessor,ILogger _logger) : IBlogService
{
  public async Task<IActionResult> CreateBlogAsync(BlogCreateDto blogCreateDto)
    {
    
        try
        {
            var userId= _httpContextAccessor.HttpContext?.Items["UserId"];
            var blog = new Blog
            {
                Title = blogCreateDto.Title,
                Content = blogCreateDto.Content,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                AuthorId = Convert.ToInt32(userId)
            };
        
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();

            
        
            return new CreatedAtRouteResult(
                "GetBlogById",
                new { id = blog.Id },

                new { message = "Blog created successfully", status = System.Net.HttpStatusCode.Created, blog = new BlogDto(blog.Id, blog.Title, blog.Content, blog.CreatedAt, blog.UpdatedAt) });
        }
        catch (System.Exception ex)
        {
            _logger.LogError($"[{DateTime.Now}] -- Error creating blog: {ex.Message}");
            return new StatusCodeResult(500);
        }
  }

  public async Task<ICollection<Blog>> GetAllBlogsAsync()
    {
        var blogs = await _context.Blogs.ToListAsync();
        return blogs;
    }

  public Task<IActionResult> GetBlogByIdAsync(int id)
  {
    try
    {
        var blog =  _context.Blogs.FirstOrDefault(b => b.Id == id);
        if (blog == null)
        {
            return Task.FromResult<IActionResult>(new NotFoundObjectResult(new { message = "Blog not found", status = System.Net.HttpStatusCode.NotFound }));
        }

        return Task.FromResult<IActionResult>(new OkObjectResult(new { message = "Blog fetched successfully", status = System.Net.HttpStatusCode.OK, blog = new BlogDto(blog.Id, blog.Title, blog.Content, blog.CreatedAt, blog.UpdatedAt) }));
    }
    catch (System.Exception ex)
        {
            
            _logger.LogError($"[{DateTime.Now}] -- Error fetching blog by id: {ex.Message}");
            return Task.FromResult<IActionResult>(new StatusCodeResult(500));
        }
    }

  public Task<IActionResult> GetBlogsByAuthorIdAsync(int authorId)
  {
    try
    {
            if (authorId <= 0)
            {
                return Task.FromResult<IActionResult>(new BadRequestObjectResult(new { message = "Invalid author id", status = System.Net.HttpStatusCode.BadRequest }));
            }
            var blogs = _context.Blogs.Where(b => b.AuthorId == authorId).ToList();

            BlogDto[] blogDtos = [.. blogs.Select(blog => new BlogDto(blog.Id, blog.Title, blog.Content, blog.CreatedAt, blog.UpdatedAt))];

            return Task.FromResult<IActionResult>(new OkObjectResult(new { message = "Blogs fetched successfully", data = blogDtos}));
        

    }
    catch (System.Exception ex)
    {
        _logger.LogError($"[{DateTime.Now}] -- Error fetching blogs by author id: {ex.Message}");
        return Task.FromResult<IActionResult>(new StatusCodeResult(500));
    }
  }
}
