namespace ClinicManagmentSystem.API.Data.Models;

public class Patient
{
    public Guid Id { get; set; }
    [MaxLength(255)]
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(255)]
    public string LastName { get; set; } = string.Empty;
    [MaxLength(25)]
    public string PhoneNumber { get; set; } = string.Empty;
    public int Age { get; set; }
    public ICollection<Appointment>? Appointments { get; set; }
}
