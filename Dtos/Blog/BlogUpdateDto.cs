using System.Text.Json.Serialization;

namespace learn.Dtos.Blog;

public record BlogUpdateDto(
[property:JsonPropertyName("title")]
    string Title,
    [property:JsonPropertyName("content")]
    string Content
);
