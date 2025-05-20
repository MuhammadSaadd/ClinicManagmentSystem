namespace ClinicManagmentSystem.API.Business.IServices;

public interface IEpisodeVisitServices
{
    Task<EpisodeVisit?> GetAsync(Guid id);
    Task<IEnumerable<EpisodeVisit>> GetAsync();
    Task AddAsync(Guid appointmentId);
}
