using learn.Models;

namespace learn.Services.BlogService;

public interface IBlogService
{
    void CreatePost(string title, string content);

    Task<ICollection<Blog>> GetAllBlogsAsync();
}