namespace ClinicManagmentSystem.API.Data.Models;

public class Clinic
{
    public Guid Id { get; set; }
    [MaxLength(255)]
    public string Title { get; set; } = string.Empty;
    [MaxLength(500)]
    public string Address { get; set; } = string.Empty;
    public bool Availiable { get; set; } = true;
    public ICollection<Shift>? Shifts { get; set; }
}
