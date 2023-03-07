namespace ClinicManagmentSystem.API.Business.IServices;

public interface IPhysicianServices
{
    Task<PhysicianResponseDto?> GetAsync(Guid id);
    Task<PhysicianResponseDto?> GetBySSNAsync(string ssn);
    Task<LoginDto?> GetByEmailAsync(string email);
    Task<IEnumerable<PhysicianResponseDto>> GetAsync();
    Task<IEnumerable<PhysicianResponseDto>> GetBySpecialtyAsync(string specialty);
    Task AddAsync(Physician physician);
    Task UpdateAsync(Physician physician);
    Task DeleteAsync(Physician physician);
}
