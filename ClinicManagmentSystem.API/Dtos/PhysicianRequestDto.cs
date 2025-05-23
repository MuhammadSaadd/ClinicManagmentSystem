﻿namespace ClinicManagmentSystem.API.Dtos;

public class PhysicianRequestDto : PhysicianDto, IValidatableObject
{
    public string Password { get; set; } = string.Empty;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrEmpty(SSN))
            yield return new ValidationResult("SSN required", new[] { nameof(SSN) });

        if (SSN.Length > 25)
            yield return new ValidationResult("SSN cannot be longer than 25 characters", new[] { nameof(SSN) });

        if (string.IsNullOrEmpty(FirstName))
            yield return new ValidationResult("First Name is required", new[] { nameof(FirstName) });

        if (FirstName.Length > 255)
            yield return new ValidationResult("First Name cannot be longer than 255 characters", new[] { nameof(FirstName) });

        if (string.IsNullOrEmpty(LastName))
            yield return new ValidationResult("Last Name is required", new[] { nameof(LastName) });

        if (LastName.Length > 255)
            yield return new ValidationResult("Last Name cannot be longer than 255 characters", new[] { nameof(LastName) });

        if (string.IsNullOrEmpty(Email))
            yield return new ValidationResult("Email is required", new[] { nameof(Email) });

        if (Email.Length > 255)
            yield return new ValidationResult("Email cannot be longer than 255 characters", new[] { nameof(Email) });

        if (string.IsNullOrEmpty(Password))
            yield return new ValidationResult("Password is required", new[] { nameof(Password) });

        if (PasswordValidator.Validate(Password!) == false)
            yield return new ValidationResult("Password must be at least 6 characters," +
                "Contains at least one lowercase letter, one uppercase letter, one number," +
                " and one special character."
                , new[] { nameof(Password) });

        if (string.IsNullOrEmpty(PhoneNumber))
            yield return new ValidationResult("PhoneNumber is required", new[] { nameof(PhoneNumber) });

        if (PhoneNumber.Length > 255)
            yield return new ValidationResult("PhoneNumber cannot be longer than 25 characters", new[] { nameof(PhoneNumber) });

        if (string.IsNullOrEmpty(Specialty))
            yield return new ValidationResult("Specialty is required", new[] { nameof(Specialty) });

        if (Specialty.Length > 255)
            yield return new ValidationResult("Specialty cannot be longer than 255 characters", new[] { nameof(Specialty) });
    }
}
