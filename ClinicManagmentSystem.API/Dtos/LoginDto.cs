namespace ClinicManagmentSystem.API.Dtos;

public class LoginDto : IValidatableObject
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrEmpty(Email))
            yield return new ValidationResult("Email is required", new[] { nameof(Email) });

        if (string.IsNullOrEmpty(Password))
            yield return new ValidationResult("Password is required", new[] { nameof(Password) });
    }
}
