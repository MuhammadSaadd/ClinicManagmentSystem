namespace ClinicManagmentSystem.API.Business.IServices;

public interface IPhysicianServices
{
    Task<Physician?> GetAsync(Guid id);
    Task<Physician?> GetBySSNAsync(string ssn);
    Task<Physician?> GetByEmailAsync(string email);
    Task<List<Physician>> GetAsync();
    Task<List<Physician>> GetBySpecialtyAsync(string specialty);
    Task AddAsync(Physician physician);
    Task UpdateAsync(Physician physician);
    Task DeleteAsync(Physician physician);
}
