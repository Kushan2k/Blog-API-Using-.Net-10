namespace learn.Models;

public class Blog
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Content { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int AuthorId { get; set; }
    public User? _author { get; set; }

}