using System.ComponentModel.DataAnnotations;

namespace ClinicManagmentSystem.API.Dtos;

public class ClinicDto
{
    public string Title { get; set; } = null!;
    [MaxLength(255)]
    public string Address { get; set; } = null!;
}
