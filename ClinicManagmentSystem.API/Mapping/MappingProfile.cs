namespace ClinicManagmentSystem.API.MapperProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Clinic
        CreateMap<Clinic, ClinicDto>();
        CreateMap<ClinicDto, Clinic>();
    }
}
