namespace ClinicManagmentSystem.API.Business.Services;

public class PhysicianServices : IPhysicianServices
{
    private readonly AppDBContext _context;

    public PhysicianServices(AppDBContext context)
    {
        _context = context;
    }

    public async Task<PhysicianResponseDto?> GetAsync(Guid id)
    {
        var physician = await _context.Physicians
                .SingleOrDefaultAsync(x => x.Id == id);

        var dto = new PhysicianResponseDto()
        {
            Id = physician!.Id,
            SSN = physician.SSN,
            FisrtName = physician.FirstName,
            LastName = physician.LastName,
            Email = physician.Email,
            PhoneNumber = physician.PhoneNumber,
            Specialty = physician.Specialty
        };

        return dto;
    }

    public async Task<PhysicianResponseDto?> GetBySSNAsync(string ssn)
    {
        var physician = await _context.Physicians
                .SingleOrDefaultAsync(x => x.SSN == ssn);

        var dto = new PhysicianResponseDto()
        {
            Id = physician!.Id,
            SSN = physician.SSN,
            FisrtName = physician.FirstName,
            LastName = physician.LastName,
            Email = physician.Email,
            PhoneNumber = physician.PhoneNumber,
            Specialty = physician.Specialty
        };

        return dto;
    }

    public async Task<LoginDto?> GetByEmailAsync(string email)
    {
        var physician = await _context.Physicians
                .SingleOrDefaultAsync(x => x.Email == email);

        var dto = new LoginDto()
        {
            Email = physician!.Email,
            Password = physician.Password,
        };

        return dto;
    }

    public async Task<List<PhysicianResponseDto>> GetAsync()
    {
        var dtos = await _context.Physicians
            .Select(p => new PhysicianResponseDto()
            {
                Id = p.Id,
                SSN = p.SSN,
                FisrtName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                PhoneNumber = p.PhoneNumber,
                Specialty = p.Specialty
            }).ToListAsync();

        return dtos;
    }

    public async Task<List<PhysicianResponseDto>> GetBySpecialtyAsync(string specialty)
    {
        var dtos = await _context.Physicians
            .Where(p => p.Specialty == specialty)
            .Select(p => new PhysicianResponseDto()
            {
                Id = p.Id,
                SSN = p.SSN,
                FisrtName = p.FirstName,
                LastName = p.LastName,
                Email = p.Email,
                PhoneNumber = p.PhoneNumber,
                Specialty = p.Specialty
            }).ToListAsync();

        return dtos;
    }

    public async Task AddAsync(Physician physician)
    {
        await _context.Physicians.AddAsync(physician);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Physician physician)
    {
        _context.Physicians.Update(physician);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Physician physician)
    {
        _context.Physicians.Remove(physician);
        await _context.SaveChangesAsync();
    }
}
