namespace ClinicManagmentSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClinicsController : ControllerBase
{
    private readonly IClinicServices _clinicService;
    private readonly IMapper _mapper;

    public ClinicsController(IClinicServices clinicService, IMapper mapper)
    {
        _clinicService = clinicService;
        _mapper = mapper;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var clinics = await _clinicService.GetAsync();

        var dto = _mapper.Map<IEnumerable<ClinicDto>>(clinics);

        return Ok(dto);
    }

    [HttpGet("Get")]
    public async Task<IActionResult> Get(string title)
    {
        var clinic = await _clinicService.GetAsync(title);

        if (clinic is null)
            return NotFound();

        var dto = _mapper.Map<ClinicDto>(clinic);

        return Ok(dto);
    }

    [HttpGet("Get/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var clinic = await _clinicService.GetAsync(id);

        if (clinic is null)
            return NotFound();

        var dto = _mapper.Map<ClinicDto>(clinic);

        return Ok(dto);
    }


    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] ClinicDto clinicDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var clinic = _mapper.Map<Clinic>(clinicDto);

        await _clinicService.AddAsync(clinic);

        return Ok();
    }

    [HttpPut("Edit/{id}")]
    public async Task<IActionResult> Edit(Guid id, [FromBody] ClinicDto clinicDto)
    {
        var clinic = await _clinicService.GetAsync(id);

        if (clinic is null)
            return NotFound();

        clinicDto.Id = id;

        clinic = _mapper.Map(clinicDto, clinic);
        await _clinicService.UpdateAsync(clinic);

        return Ok();
    }

    [HttpDelete("Remove")]
    public async Task<IActionResult> Remove(Guid id)
    {
        var clinic = await _clinicService.GetAsync(id);

        if (clinic is null)
            return NotFound();

        await _clinicService.DeleteAsync(clinic);

        return NoContent();
    }
}
