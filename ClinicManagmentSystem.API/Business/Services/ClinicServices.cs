namespace ClinicManagmentSystem.API.Business.Services;

public class ClinicServices : IClinicServices
{
    private readonly AppDBContext _context;

    public ClinicServices(AppDBContext context)
    {
        _context = context;
    }

    public Task<Clinic?> GetAsync(Guid id)
    {
        return _context.Clinics.FirstOrDefaultAsync(c => c.Id == id);
    }

    public Task<List<Clinic>> GetAsync()
    {    
        return _context.Clinics.ToListAsync();
    }
    
    public Task<Clinic?> GetAsync(string title)
    {
        return _context.Clinics.FirstOrDefaultAsync(c => c.Title == title);
    }

    public async Task AddAsync(Clinic clinic)
    {
        await _context.AddAsync(clinic);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Clinic clinic)
    {
        _context.Update(clinic);
        await _context.SaveChangesAsync();
    }
    
    public async Task DeleteAsync(Clinic clinic)
    {
        _context.Remove(clinic);
        await _context.SaveChangesAsync();
    }

}
