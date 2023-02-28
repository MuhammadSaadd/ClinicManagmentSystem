namespace ClinicManagmentSystem.API.MapperProfiles;

public class ClinicProfile : Profile
{
	public ClinicProfile()
	{
		CreateMap<Clinic, ClinicDto>();
	}
}
