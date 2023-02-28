using ClinicManagmentSystem.API.Dtos;

namespace ClinicManagmentSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClinicsController : ControllerBase
{
    private readonly IClinicServices _clinicService;

    public ClinicsController(AppDBContext context, IClinicServices clinicService)
    {
        _clinicService = clinicService;
    }

    [HttpGet("Get")]
    public async Task<IActionResult> Get()
    {
        var clinics = await _clinicService.GetAsync();
        return Ok(clinics);
    }

    [HttpGet("Get/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var clinic = await _clinicService.GetAsync(id);
        return Ok(clinic);
    }

    [HttpGet("Get/{title}")]
    public async Task<IActionResult> Get(string title)
    {
        var clinic = await _clinicService.GetAsync(title);
        return Ok(clinic);
    }

    [HttpPost("Add")]
    public async Task Add(ClinicDto clinicDto)
    {
        
    }
}
