using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace learn.Dtos.User;


public record UserLoginDto(
    [property:JsonPropertyName("email")]
    [Required][EmailAddress]string Email,
    [property:JsonPropertyName("password")]
    [Required]string Password
);