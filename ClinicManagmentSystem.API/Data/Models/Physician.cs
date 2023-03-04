namespace ClinicManagmentSystem.API.Data.Models;

public class Physician
{
    public Guid Id { get; set; }
    [MaxLength(25)]
    public string SSN { get; set; } = string.Empty;
    [MaxLength(255)]
    public string FisrtName { get; set; } = string.Empty;
    [MaxLength(255)]
    public string LastName { get; set; } = string.Empty;
    [MaxLength(255)]
    public string Email { get; set; } = string.Empty;
    [MaxLength(255)]
    public string Password { get; set; } = string.Empty;
    [MaxLength(25)]
    public string PhoneNumber { get; set; } = string.Empty;
    [MaxLength(255)]
    public string Specialty { get; set; } = string.Empty;
    public ICollection<Shift>? Shifts { get; set; }
    public ICollection<Appointment>? Appointments { get; set; }
}
