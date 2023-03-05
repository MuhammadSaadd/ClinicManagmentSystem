namespace ClinicManagmentSystem.API.Business.IServices;

public interface IPhysicianServices
{
    Task<PhysicianDto?> GetAsync(Guid id);
    Task<PhysicianDto?> GetBySSNAsync(string ssn);
    Task<PhysicianDto?> GetByEmailAsync(string email);
    Task<List<PhysicianDto>> GetAsync();
    Task<List<PhysicianDto>> GetBySpecialtyAsync(string specialty);
    Task AddAsync(Physician physician);
    Task UpdateAsync(PhysicianDto physicianDto);
    Task DeleteAsync(PhysicianDto physicianDto);
}
