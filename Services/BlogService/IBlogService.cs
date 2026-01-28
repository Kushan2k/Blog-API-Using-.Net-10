using learn.Dtos.Blog;
using learn.Models;
using Microsoft.AspNetCore.Mvc;

namespace learn.Services.BlogService;

public interface IBlogService
{
    Task<IActionResult> CreateBlogAsync(BlogCreateDto blogCreateDto);
    Task<IActionResult> DeleteBlogAsync(int id, int v);
    Task<ICollection<Blog>> GetAllBlogsAsync();

    Task<IActionResult> GetBlogByIdAsync(int id);
    Task<IActionResult> GetBlogsByAuthorIdAsync(int authorId);
    Task<IActionResult> UpdateBlogAsync(int id, BlogUpdateDto blogUpdateDto, int v);
}
