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

    public async Task<IEnumerable<Shift>> GetAllAsync()
    {
        return await _context.Shifts.ToListAsync();
    }

    public async Task AddAsync(Shift shift)
    {
        await _context.Shifts.AddAsync(shift);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsShiftAvailableAsync(ShiftRequestDto shiftDto)
    {
        var oldShifts = await _context.Shifts
            .Where(oldShift => oldShift.Finished == false)
            .Where(oldShift => oldShift.StartTime > shiftDto.StartTime)
            .Where(oldShift => oldShift.EndTime < shiftDto.EndTime)
            .ToListAsync();

        return !oldShifts.Any();
    }

    public async Task MarkShiftAsFinishedAsync(Guid id)
    {
        var shift = await _context.Shifts.SingleOrDefaultAsync(sh => sh.Id == id);

        shift!.Finished = true;

        _context.Shifts.Update(shift);

        await _context.SaveChangesAsync();
    }
}


#region IsShiftAvailableAsync
// var currentShifts = await _context.Shifts
// .Where(sh => sh.PhysicianId == shiftDto.PhysicianId)
// .Where(sh => sh.ClinicId == shiftDto.ClinicId)
// .Where(sh => sh.Finished == false)
#endregion