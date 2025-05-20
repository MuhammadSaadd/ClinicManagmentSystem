namespace ClinicManagmentSystem.API.Dtos;

public class PrescriptionDto
{
    public Guid PhysicianId { get; set; }
    public Guid PatientId { get; set; }
    public string Prescriptions { get; set; } = string.Empty;
}
