namespace ClinicManagmentSystem.API.Business.IServices;

public interface IShiftServices
{
    Task<Shift?> GetAsync(Guid id);
    Task<List<Shift>> GetAllAsync();
    Task AddAsync(Shift shift);
    Task UpdateAsync(Shift shift);
    Task DeleteAsync(Shift shift);
}
