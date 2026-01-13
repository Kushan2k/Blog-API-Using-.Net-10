
namespace learn.Dtos.Blog;


public record BlogDto(
    int Id,
    string Title,
    string Content,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

