using System.ComponentModel.DataAnnotations;
using Flowly.Features.Auth.CustomAnnotation;

namespace Flowly.Features.Auth.DTOs;

public record CreateRequestDto
{
    [Required]
    public string FullName { get; set; } = string.Empty;


    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;


    [PasswordAnnotation]
    public string Password { get; set; } = string.Empty;
}
