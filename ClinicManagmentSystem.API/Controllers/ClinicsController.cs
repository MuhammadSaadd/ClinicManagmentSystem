namespace ClinicManagmentSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClinicsController : ControllerBase
{
    private readonly IClinicServices _clinicServices;
    private readonly IMapper _mapper;

    public ClinicsController(IClinicServices clinicServices, IMapper mapper)
    {
        _clinicServices = clinicServices;
        _mapper = mapper;
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var clinic = await _clinicServices.GetAsync(id);

        if (clinic is null)
            return NotFound();

        var dto = _mapper.Map<ClinicResponseDto>(clinic);

        return Ok(dto);
    }

    [HttpGet("GetByTitle/{title}")]
    public async Task<IActionResult> Get(string title)
    {
        var clinic = await _clinicServices.GetAsync(title);

        if (clinic is null)
            return NotFound();

        var dto = _mapper.Map<ClinicResponseDto>(clinic);

        return Ok(dto);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var clinics = await _clinicServices.GetAsync();

        var clinicDtos = _mapper.Map<IEnumerable<ClinicResponseDto>>(clinics);

        return Ok(clinicDtos);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] ClinicRequestDto clinicDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var clinic = _mapper.Map<Clinic>(clinicDto);
        clinic.Id = Guid.NewGuid();

        await _clinicServices.AddAsync(clinic);

        return Ok();
    }

    [HttpPut("Edit/{id}")]
    public async Task<IActionResult> Edit(Guid id, [FromBody] ClinicRequestDto clinicDto)
    {
        var clinic = await _clinicServices.GetAsync(id);

        if (clinic is null)
            return NotFound();

        clinic = _mapper.Map(clinicDto, clinic);

        await _clinicServices.UpdateAsync(clinic);

        return NoContent();
    }

    [HttpDelete("Remove/{id}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        var clinic = await _clinicServices.GetAsync(id);

        if (clinic is null)
            return NotFound();

        await _clinicServices.DeleteAsync(clinic);

        return NoContent();
    }
}
