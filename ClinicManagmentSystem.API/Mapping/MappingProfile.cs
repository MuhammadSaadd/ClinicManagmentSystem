namespace ClinicManagmentSystem.API.MapperProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Clinic
        CreateMap<Clinic, ClinicDto>();
        CreateMap<ClinicDto, Clinic>();

        // Physician
        CreateMap<Physician, PhysicianDto>();
        CreateMap<PhysicianDto, Physician>();

        //Shift
        CreateMap<Shift, ShiftDto>();
        CreateMap<ShiftDto, Shift>();
    }
}
