namespace ClinicManagmentSystem.API.Data.Models;

public class Clinic
{
    public Guid Id { get; set; }
    [MaxLength(255)]
    public string Title { get; set; } = String.Empty;
    [MaxLength(255)]
    public string Address { get; set; } = String.Empty;
    public ICollection<Shift>? Shifts { get; set; }
}
