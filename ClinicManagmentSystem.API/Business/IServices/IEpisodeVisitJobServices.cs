namespace ClinicManagmentSystem.API.Business.IServices;

public interface IEpisodeVisitJobServices
{
    Task<EpisodeVisitJob?> GetAsync(string appointmentJobId);
    Task AddAsync(EpisodeVisitJob episodeVisitJob);
    Task DeleteAsync(EpisodeVisitJob episodeVisitJob);
}
