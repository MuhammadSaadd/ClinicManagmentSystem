using System.ComponentModel.DataAnnotations;

namespace ClinicManagmentSystem.API.Data.Models;

public class Clinic
{
    public Guid Id { get; set; }
    [MaxLength(255)]
    public string Title { get; set; } = null!;
    [MaxLength(255)]
    public string Address { get; set; } = null!;
    public ICollection<Shift>? Shifts { get; set; }
}
