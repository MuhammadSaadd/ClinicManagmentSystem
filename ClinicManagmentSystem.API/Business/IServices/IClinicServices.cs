namespace ClinicManagmentSystem.API.Business.IServices;

public interface IClinicServices
{
    Task<IEnumerable<Clinic>> GetAsync();
    Task<Clinic?> GetAsync(Guid id);
    Task<Clinic?> GetAsync(string title);
    Task AddAsync(Clinic clinic);
    Task UpdateAsync(Clinic clinic);
    Task DeleteAsync(Clinic clinic);
}
