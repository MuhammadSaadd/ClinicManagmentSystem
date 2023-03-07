namespace ClinicManagmentSystem.API.Dtos;

public class PatientRequestDto : IValidatableObject
{
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(255)]
    public string LastName { get; set; } = string.Empty;
    [MaxLength(25)]
    public string PhoneNumber { get; set; } = string.Empty;
    public int Age { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrEmpty(FirstName))
            yield return new ValidationResult("First Name is required",
                new[] { nameof(FirstName) });

        if (FirstName.Length > 255)
            yield return new ValidationResult("First Name cannot be longer than 255 characters",
                new[] { nameof(FirstName) });

        if (string.IsNullOrEmpty(LastName))
            yield return new ValidationResult("Last Name is required",
                new[] { nameof(LastName) });

        if (LastName.Length > 255)
            yield return new ValidationResult("Last Name cannot be longer than 255 characters",
                new[] { nameof(LastName) });

        if (string.IsNullOrEmpty(PhoneNumber))
            yield return new ValidationResult("Phone Number is required",
                new[] { nameof(PhoneNumber) });

        if (PhoneNumber.Length > 255)
            yield return new ValidationResult("Phone Number cannot be longer than 25 characters",
                new[] { nameof(PhoneNumber) });
    }
}
