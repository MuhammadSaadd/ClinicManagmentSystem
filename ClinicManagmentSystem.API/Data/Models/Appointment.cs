namespace ClinicManagmentSystem.API.Data.Models;

public class Appointment
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool EpisodeVisitFlag { get; set; } = false;
    public bool Canceled { get; set; }
    public string JopId { get; set; } = string.Empty;
    public Guid PatientId { get; set; }
    public Patient? Patient { get; set; }
    public Guid PhysicianId { get; set; }
    public Physician? Physician { get; set; }
    public EpisodeVisit? EpisodeVisit { get; set; }
}
