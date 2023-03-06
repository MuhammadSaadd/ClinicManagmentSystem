namespace ClinicManagmentSystem.API.Dtos;

public class ShiftDto
{
    [Required] public Guid ClinicId { get; set; }
    [Required] public Guid PhysicianId { get; set; }
    [Required] public DateTime StartTime { get; set; }
    [Required] public DateTime EndTime { get; set; }
}

