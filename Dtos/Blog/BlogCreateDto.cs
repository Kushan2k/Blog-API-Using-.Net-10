using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace learn.Dtos.Blog;

public record BlogCreateDto(
    [property:JsonPropertyName("title")]
    [Required][MinLength(5)][MaxLength(100)] string Title,
    [property:JsonPropertyName("content")]
    [Required][MinLength(10)][MaxLength(1000)] string Content
);
