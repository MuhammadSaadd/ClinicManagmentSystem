namespace ClinicManagmentSystem.API.Dtos;

public class ClinicResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}
