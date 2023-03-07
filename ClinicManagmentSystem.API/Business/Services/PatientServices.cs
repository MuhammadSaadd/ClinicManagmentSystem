namespace ClinicManagmentSystem.API.Business.Services;

public class PatientServices : IPatientServices
{
    private readonly AppDBContext _context;

    public PatientServices(AppDBContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Patient>> GetAsync()
    {
        return await _context.Patients.ToListAsync();
    }

    public async Task<Patient?> GetAsync(Guid id)
    {
        return await _context.Patients.SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task AddAsync(Patient patient)
    {
        await _context.Patients.AddAsync(patient);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Patient patient)
    {
        _context.Patients.Update(patient);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Patient patient)
    {
        _context.Patients.Remove(patient);
        await _context.SaveChangesAsync();
    }
}

