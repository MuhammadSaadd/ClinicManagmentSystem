namespace ClinicManagmentSystem.API.Business.Services;

public class ShiftServices : IShiftServices
{
    private readonly AppDBContext _context;

    public ShiftServices(AppDBContext context)
    {
        _context = context;
    }

    public async Task<Shift?> GetAsync(Guid id)
    {
        return await _context.Shifts.SingleOrDefaultAsync(sh => sh.Id == id);
    }

    public async Task<List<Shift>> GetAllAsync()
    {
        return await _context.Shifts.ToListAsync();
    }

    
    public async Task AddAsync(Shift shift)
    {
        await _context.Shifts.AddAsync(shift);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Shift shift)
    {
        _context.Shifts.Update(shift);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Shift shift)
    {
        _context.Shifts.Remove(shift); 
        await _context.SaveChangesAsync();
    }
}
