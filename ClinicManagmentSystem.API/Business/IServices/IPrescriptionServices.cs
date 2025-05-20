namespace ClinicManagmentSystem.API.Business.IServices;

public interface IPrescriptionServices
{
    Task<IEnumerable<Prescription>> GetAsync();
    Task<Prescription?> GetAsync(string id);
    Task CreateAsync(Prescription prescription);
    Task UpdateAsync(string id, Prescription prescription);
    Task DeleteAsync(string id);
}