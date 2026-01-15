using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace learn.Dtos.User;

public record UserCreateDto(

    [property:JsonPropertyName("email")]
    [Required][EmailAddress] string Email,
    [property:JsonPropertyName("password")]
    [Required][MinLength(6)] string Password,
    [property:JsonPropertyName("full_name")]
    [Required] string FullName,
    [property:JsonPropertyName("confirm_password")]
    [Required] string ConfirmPassword
);
