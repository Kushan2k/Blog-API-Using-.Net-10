using System.Net;
using learn.Services.BlogService;
using Microsoft.AspNetCore.Mvc;

namespace learn.Controllers;

[ApiController]
[Route("api/blogs")]
public class BlogsController : ControllerBase
{

    private readonly IBlogService _blogService;

    public BlogsController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllBlogs()
    {


        return Ok(new { message = "All Blogs fetched successfully", data = await _blogService.GetAllBlogsAsync(), status = HttpStatusCode.OK });
    }

}