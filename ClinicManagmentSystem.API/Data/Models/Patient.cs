using System.ComponentModel.DataAnnotations;

namespace ClinicManagmentSystem.API.Data.Models;

public class Patient
{
    public Guid Id { get; set; }
    [MaxLength(255)]
    public string FirstName { get; set; } = null!;
    [MaxLength(255)]
    public string LastName { get; set; } = null!;
    [MaxLength(25)]
    public string PhoneNumber { get; set; } = null!;
    public int Age { get; set; }
    public ICollection<Appointment>? Appointments { get; set; }
}
