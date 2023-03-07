namespace ClinicManagmentSystem.API.Business.Services;

public class EpisodeVisitJobServices : IEpisodeVisitJobServices
{
    private readonly AppDBContext _context;

    public EpisodeVisitJobServices(AppDBContext context)
    {
        _context = context;
    }

    public async Task<EpisodeVisitJob?> GetAsync(string appointmentJobId)
    {
        return await _context.EpisodeVisitJobs
            .SingleOrDefaultAsync(e => e.AppointmentJobId == appointmentJobId);
    }

    public async Task AddAsync(EpisodeVisitJob episodeVisitJob)
    {
        await _context.EpisodeVisitJobs.AddAsync(episodeVisitJob);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(EpisodeVisitJob episodeVisitJob)
    {
        _context.EpisodeVisitJobs.Remove(episodeVisitJob);
        await _context.SaveChangesAsync();
    }
}
