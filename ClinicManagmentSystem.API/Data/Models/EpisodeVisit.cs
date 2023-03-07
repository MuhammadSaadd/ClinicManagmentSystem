namespace ClinicManagmentSystem.API.Data.Models;

public class EpisodeVisit
{
    public Guid Id { get; set; }
    public Guid AppointmentId { get; set; }
    public Appointment Appointment { get; set; } = null!;
}
