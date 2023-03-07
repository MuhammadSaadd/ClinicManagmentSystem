namespace ClinicManagmentSystem.API.Business.IServices;

public interface IShiftServices
{
    Task<Shift?> GetAsync(Guid id);
    Task<IEnumerable<Shift>> GetAllAsync();
    Task AddAsync(Shift shift);
    Task<bool> IsShiftAvailableAsync(ShiftRequestDto shiftDto);
    Task MarkShiftAsFinishedAsync(Guid id);
}
