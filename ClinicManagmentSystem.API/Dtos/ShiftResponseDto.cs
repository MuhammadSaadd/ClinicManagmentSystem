namespace ClinicManagmentSystem.API.Dtos;

public class ShiftResponseDto : ShiftDto
{
    public Guid Id { get; set; }
    public bool Finished { get; set; }
}
