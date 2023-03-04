namespace ClinicManagmentSystem.API.Business.Services;

public class PhysicianServices : IPhysicianServices
{
    private readonly AppDBContext _context;

    public PhysicianServices(AppDBContext context)
    {
        _context = context;
    }

    public Task<Physician?> GetAsync(Guid id)
    {
        return _context.Physicians.FirstOrDefaultAsync(p => p.Id == id);
    }

    public Task<Physician?> GetBySSNAsync(string ssn)
    {
        return _context.Physicians.FirstOrDefaultAsync(p => p.SSN == ssn);
    }

    public Task<List<Physician>> GetAsync()
    {
        return _context.Physicians.ToListAsync();
    }

    public async Task<List<Physician>> GetBySpecialtyAsync(string specialty)
    {
        return await _context.Physicians
            .Where(p => p.Specialty == specialty).ToListAsync();
    }

    public async Task<Physician?> GetByEmailAsync(string email)
    {
        return await _context.Physicians.SingleOrDefaultAsync(p => p.Email == email);
    }

    public async Task AddAsync(Physician physician)
    {
        await _context.Physicians.AddAsync(physician);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Physician physician)
    {
        _context.Physicians.Update(physician);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Physician physician)
    {
        _context.Physicians.Remove(physician);
        await _context.SaveChangesAsync();
    }
}
