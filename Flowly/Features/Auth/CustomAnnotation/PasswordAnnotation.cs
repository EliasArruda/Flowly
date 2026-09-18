using System.ComponentModel.DataAnnotations;

namespace Flowly.Features.Auth.CustomAnnotation;

public class PasswordAnnotation : ValidationAttribute
{
    public int MinimumLength { get; set; } = 8;
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not string password || string.IsNullOrWhiteSpace(password))
            return new ValidationResult("Password is required.");

        if (password.Length < MinimumLength)
            return new ValidationResult($"Minimum {MinimumLength} characters.");

        if (!password.Any(char.IsUpper))
            return new ValidationResult("Add an uppercase letter.");

        if (!password.Any(char.IsLower))
            return new ValidationResult("Add a lowercase letter.");

        if (!password.Any(char.IsDigit))
            return new ValidationResult("Add a number.");

        if (!password.Any(c => !char.IsLetterOrDigit(c)))
            return new ValidationResult("Add a special character.");

        return ValidationResult.Success;
    }
}
