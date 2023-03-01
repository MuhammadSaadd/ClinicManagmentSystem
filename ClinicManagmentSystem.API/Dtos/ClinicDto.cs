namespace ClinicManagmentSystem.API.Dtos;

public class ClinicDto : IValidatableObject
{
    public Guid? Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;


    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {

        if (string.IsNullOrEmpty(Title))
            yield return new ValidationResult("Title is required", new[] { nameof(Title) });

        if (Title.Length > 255)
            yield return new ValidationResult("Title cannot be longer than 255 characters", new[] { nameof(Title) });

        if (string.IsNullOrEmpty(Address))
            yield return new ValidationResult("Address is required", new[] { nameof(Address) });

        if (Address?.Length > 255)
            yield return new ValidationResult("Address cannot be longer than 255 characters", new[] { nameof(Address) });
    }
}
