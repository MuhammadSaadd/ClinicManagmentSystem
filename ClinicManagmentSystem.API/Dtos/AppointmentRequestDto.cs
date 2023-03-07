namespace ClinicManagmentSystem.API.Dtos;

public class AppointmentRequestDto
{
    public Guid PatientId { get; set; }
    public Guid PhysicianId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
