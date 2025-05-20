namespace ClinicManagmentSystem.API.Business.Services;

public class EpisodeVisitServices : IEpisodeVisitServices
{
    private readonly AppDBContext _context;

    public EpisodeVisitServices(AppDBContext context)
    {
        _context = context;
    }

    public async Task<EpisodeVisit?> GetAsync(Guid id)
    {
        return await _context.EpisodeVisits.SingleOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<EpisodeVisit>> GetAsync()
    {
        return await _context.EpisodeVisits.ToListAsync();
    }

    public async Task AddAsync(Guid appointmentId)
    {
        var episodeVisit = new EpisodeVisit
        {
            Id = Guid.NewGuid(),
            AppointmentId = appointmentId,
        };

        await _context.EpisodeVisits.AddAsync(episodeVisit);

        await _context.SaveChangesAsync();
    }
}
