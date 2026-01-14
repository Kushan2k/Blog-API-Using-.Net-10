using learn.Data;
using learn.Models;
using Microsoft.EntityFrameworkCore;

namespace learn.Services.BlogService;


public class BlogService(ApplicationDbContext _context) : IBlogService
{
    public void CreatePost(string title, string content)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<Blog>> GetAllBlogsAsync()
    {
        var blogs = await _context.Blogs.ToListAsync();
        return blogs;
    }
}