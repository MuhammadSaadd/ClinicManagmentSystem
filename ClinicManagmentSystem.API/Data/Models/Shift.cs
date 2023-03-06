namespace ClinicManagmentSystem.API.Data.Models;

public class Shift
{
    public Guid Id { get; set; }
    [DataType(DataType.DateTime)]
    public DateTime StartTime { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime EndTime { get; set; }

    public bool Finished { get; set; } = false;

    public Guid ClinicId { get; set; }
    public Clinic Clinic { get; set; } = null!;

    public Guid PhysicianId { get; set; }
    public Physician Physician { get; set; } = null!;
}
