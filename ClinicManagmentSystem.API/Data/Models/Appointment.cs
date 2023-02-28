namespace ClinicManagmentSystem.API.Data.Models;

public class Appointment
{
    public Guid Id { get; set; }
    public Guid? PatientId { get; set; }
    public Guid? PhysicianId { get; set; }
    public bool Canceled { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public bool EposideVisitFlag { get; set; } = false;
    public Patient? Patient { get; set; }
    public Physician? Physician { get; set; }
    public EpisodeVisit? EpisodeVisit { get; set; }
}
