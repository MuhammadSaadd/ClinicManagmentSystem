namespace ClinicManagmentSystem.API.Data.Models;

public class Shift
{
    public Guid Id { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime From { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime To { get; set; }
    public bool Finished { get; set; } = false;
    public Guid ClinicId { get; set; }
    public Guid PhysicianId { get; set; }
    public Clinic Clinic { get; set; } = null!;
    public Physician Physician { get; set; } = null!;
}
