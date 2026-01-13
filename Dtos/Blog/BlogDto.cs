
namespace learn.Dtos;


public record BlogDto(
    int Id,
    string Title,
    string Content,
    DateTime CreatedAt,
    DateTime UpdatedAt
);

