namespace learn.Models;

public class User
{
    public int Id { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }

    public required string PasswordHash { get; set; }


    public ICollection<Blog> Blogs { get; set; } = new List<Blog>();
}