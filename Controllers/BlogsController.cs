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


        return Ok(new { message = "All Blogs fetched successfully", data = await _blogService.GetAllBlogsAsync(), status = HttpStatusCode.OK });
    }

    [HttpGet("/{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetBlogById(int id)
    {

        return Ok(new { message = "Blog fetched successfully", status = HttpStatusCode.OK });
    }


    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateBlog([FromBody] BlogCreateDto blogCreateDto)
    {
        return Ok(new { message = "Blog created successfully", status = HttpStatusCode.OK });
    }

}
