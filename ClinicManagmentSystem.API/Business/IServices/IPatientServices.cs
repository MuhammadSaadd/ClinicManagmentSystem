namespace ClinicManagmentSystem.API.Business.IServices;

public interface IPatientServices
{
    Task<IEnumerable<Patient>> GetAsync();
    Task<Patient?> GetAsync(Guid id);
    Task AddAsync(Patient patient);
    Task UpdateAsync(Patient patient);
    Task DeleteAsync(Patient patient);
}
