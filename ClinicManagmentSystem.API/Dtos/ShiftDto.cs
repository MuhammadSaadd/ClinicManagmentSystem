namespace ClinicManagmentSystem.API.Dtos;

public class ShiftDto
{
    public Guid? Id { get; set; }
    [Required] public Guid ClinicId { get; set; }
    [Required] public Guid PhysicianId { get; set; }
    [Required] public DateTime From { get; set; }
    [Required] public DateTime To { get; set; }
}
