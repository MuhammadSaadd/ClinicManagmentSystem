namespace ClinicManagmentSystem.API.MapperProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Clinic
        CreateMap<Clinic, ClinicDto>().ReverseMap();

        // Physician
        CreateMap<Physician, PhysicianRequestDto>().ReverseMap();

        CreateMap<Physician, PhysicianResponseDto>().ReverseMap();

        //Shift
        CreateMap<Shift, ShiftRequestDto>().ReverseMap();
        CreateMap<Shift, ShiftResponseDto>().ReverseMap();
    }
}
