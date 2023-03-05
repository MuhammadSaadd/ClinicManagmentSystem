namespace ClinicManagmentSystem.API.Business.Services;

public class PhysicianServices : IPhysicianServices
{
    private readonly AppDBContext _context;
    private readonly IMapper _mapper;

    public PhysicianServices(AppDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PhysicianDto?> GetAsync(Guid id)
    {
        var physician = await _context.Physicians
                .SingleOrDefaultAsync(x => x.Id == id);

        var dto = new PhysicianDto()
        {
            Id = physician!.Id,
            SSN = physician.SSN,
            FisrtName = physician.FirstName,
            LastName = physician.LastName,
            Email = physician.Email,
            Password = null,
            PhoneNumber = physician.PhoneNumber,
            Specialty = physician.Specialty
        };

        return dto;
    }

    public async Task<PhysicianDto?> GetBySSNAsync(string ssn)
    {
        var physician = await _context.Physicians
                .SingleOrDefaultAsync(x => x.SSN == ssn);

        var dto = new PhysicianDto()
        {
            Id = physician!.Id,
            SSN = physician.SSN,
            FisrtName = physician.FirstName,
            LastName = physician.LastName,
            Email = physician.Email,
            Password = null,
            PhoneNumber = physician.PhoneNumber,
            Specialty = physician.Specialty
        };

        return dto;
    }

    public async Task<PhysicianDto?> GetByEmailAsync(string email)
    {
        var physician = await _context.Physicians
                .SingleOrDefaultAsync(x => x.Email == email);

        var dto = new PhysicianDto()
        {
            Id = physician!.Id,
            SSN = physician.SSN,
            FisrtName = physician.FirstName,
            LastName = physician.LastName,
            Email = physician.Email,
            Password = physician.Password,
            PhoneNumber = physician.PhoneNumber,
            Specialty = physician.Specialty
        };

        return dto;
    }

    public async Task<List<PhysicianDto>> GetAsync()
    {
        var dtos = await _context.Physicians.Select(p => new PhysicianDto()
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

    public async Task<List<PhysicianDto>> GetBySpecialtyAsync(string specialty)
    {
        var dtos = await _context.Physicians
            .Where(p => p.Specialty == specialty)
            .Select(p => new PhysicianDto()
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

    public async Task UpdateAsync(PhysicianDto physicianDto)
    {
        var physician = await _context.Physicians
            .SingleOrDefaultAsync(p => p.Id == physicianDto.Id);
        
        physician = _mapper.Map(physicianDto, physician);

        _context.Physicians.Update(physician!);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(PhysicianDto physicianDto)
    {
        var physician = await _context.Physicians
                .SingleOrDefaultAsync(p => p.Id == physicianDto.Id);

        physician = _mapper.Map(physicianDto, physician);

        _context.Physicians.Remove(physician!);

        await _context.SaveChangesAsync();
    }
}
