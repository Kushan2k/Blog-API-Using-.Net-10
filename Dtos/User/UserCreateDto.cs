using System.ComponentModel.DataAnnotations;

namespace learn.Dtos.User;

public record UserCreateDto(
    [Required][EmailAddress] string Email,
    [Required][MinLength(6)] string Password,
    [Required] string FullName,
    [Required] string ConfirmPassword
);