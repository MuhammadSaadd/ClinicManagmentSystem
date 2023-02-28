using System.ComponentModel.DataAnnotations;

namespace ClinicManagmentSystem.API.Data.Models;

public class Physician
{
    public Guid Id { get; set; }
    public int SSN { get; set; }
    [MaxLength(255)]
    public string FisrtName { get; set; } = null!;
    [MaxLength(255)]
    public string LastName { get; set; } = null!;
    [MaxLength(255)]
    public string Email { get; set; } = null!;
    [MaxLength(255)]
    public string Password { get; set; } = null!;
    [MaxLength(25)]
    public string PhoneNumber { get; set; } = null!;
    [MaxLength(255)]
    public string Specialty { get; set; } = null!;
    public ICollection<Shift>? Shifts { get; set; }
    public ICollection<Appointment>? Appointments { get; set; }
}
