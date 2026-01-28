using System.Net;
using learn.Dtos.Blog;
using learn.Services.BlogService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace learn.Controllers;

[ApiController]
[Route("api/blogs")]
public class BlogsController(IBlogService blogService) : ControllerBase
{

    private readonly IBlogService _blogService = blogService;

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult> GetAllBlogs()
    {
        Console.WriteLine("userid from middleware: " + HttpContext.Items["UserId"]);

        return Ok(new { message = "All Blogs fetched successfully", data = await _blogService.GetAllBlogsAsync(), status = HttpStatusCode.OK });
    }

    [HttpGet("{id}", Name = "GetBlogById")]
    [AllowAnonymous]
    public async Task<IActionResult> GetBlogById(int id)
    {

        return await _blogService.GetBlogByIdAsync(id);
    }


    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateBlog([FromBody] BlogCreateDto blogCreateDto)
    {
        return await _blogService.CreateBlogAsync(blogCreateDto);
    }


    [HttpGet("myblogs")]
    [Authorize]
    public async Task<IActionResult> GetMyBlogs()
    {
        var userId = HttpContext.Items["UserId"];
        if (userId == null)
        {
            return Unauthorized(new { message = "User not authorized", status = HttpStatusCode.Unauthorized });
        }

        var blogs = await _blogService.GetBlogsByAuthorIdAsync(Convert.ToInt32(userId));

        return Ok(new { message = "User's Blogs fetched successfully", data = blogs, status = HttpStatusCode.OK });
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> DeleteBlog(int id)
    {
        var userId = HttpContext.Items["UserId"];
        if (userId == null)
        {
            return Unauthorized(new { message = "User not authorized", status = HttpStatusCode.Unauthorized });
        }

        return await _blogService.DeleteBlogAsync(id, Convert.ToInt32(userId));
    }


    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateBlog(int id, [FromBody] BlogUpdateDto blogUpdateDto)
    {
        var userId = HttpContext.Items["UserId"];
        if (userId == null)
        {
            return Unauthorized(new { message = "User not authorized", status = HttpStatusCode.Unauthorized });
        }

        return await _blogService.UpdateBlogAsync(id, blogUpdateDto, Convert.ToInt32(userId));
    }

}
