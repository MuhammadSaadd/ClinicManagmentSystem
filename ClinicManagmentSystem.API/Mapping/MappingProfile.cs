namespace ClinicManagmentSystem.API.MapperProfiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Clinic
        CreateMap<Clinic, ClinicResponseDto>().ReverseMap();
        CreateMap<Clinic, ClinicRequestDto>().ReverseMap();

        // Physician
        CreateMap<Physician, PhysicianRequestDto>().ReverseMap();
        CreateMap<Physician, PhysicianResponseDto>().ReverseMap();

        // Shift
        CreateMap<Shift, ShiftRequestDto>().ReverseMap();
        CreateMap<Shift, ShiftResponseDto>().ReverseMap();

        // Patient
        CreateMap<Patient, PatientRequestDto>().ReverseMap();
        CreateMap<Patient, PatientResponseDto>().ReverseMap();

        // Appointment
        CreateMap<Appointment, AppointmentRequestDto>().ReverseMap();
        CreateMap<Appointment, AppointmentResponseDto>().ReverseMap();
    }
}
