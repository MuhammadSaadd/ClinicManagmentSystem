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

    public async Task<bool> IsShiftAvailable(ShiftRequestDto shiftDto)
    {
        var currentShifts = await _context.Shifts
            .Where(sh => sh.PhysicianId == shiftDto.PhysicianId
                   && sh.ClinicId == shiftDto.ClinicId
                   && sh.Finished == false)
            .ToListAsync();

        foreach (var shift in currentShifts)
        {
            // in case : new shift start before existed shift finish
            if (shiftDto.StartTime < shift.EndTime)
                return false;

            // in case : new shift end after existed shift should start
            if (shiftDto.EndTime > shift.StartTime)
                return false;
        }

        return true;
    }

    public async Task MarkShiftAsFinished(Guid id)
    {
        var shift = await _context.Shifts.SingleOrDefaultAsync(sh => sh.Id == id);

        shift!.Finished = true;

        _context.Shifts.Update(shift);

        await _context.SaveChangesAsync();
    }
}
