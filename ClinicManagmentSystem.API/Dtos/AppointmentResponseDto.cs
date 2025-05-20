namespace ClinicManagmentSystem.API.Dtos;

public class AppointmentResponseDto
{
    public Guid Id { get; set; }
    public bool Canceled { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool EposideVisitFlag { get; set; }
    public Guid PatientId { get; set; }
    public Guid PhysicianId { get; set; }
}
