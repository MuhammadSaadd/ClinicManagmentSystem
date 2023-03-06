namespace ClinicManagmentSystem.API.Business.IServices;

public interface IShiftServices
{
    Task<Shift?> GetAsync(Guid id);
    Task<List<Shift>> GetAllAsync();
    Task AddAsync(Shift shift);
    Task<bool> IsShiftAvailable(ShiftRequestDto shiftDto);
    Task MarkShiftAsFinished(Guid id);
}
