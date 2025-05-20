namespace ClinicManagmentSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly IPatientServices _patientServices;
    private readonly IMapper _mapper;

    public PatientsController(IPatientServices patientServices, IMapper mapper)
    {
        _patientServices = patientServices;
        _mapper = mapper;
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var patient = await _patientServices.GetAsync(id);

        if (patient is null)
            return NotFound();

        var dto = _mapper.Map<PatientResponseDto>(patient);

        return Ok(dto);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var patients = await _patientServices.GetAsync();

        var patientDtos = _mapper.Map<IEnumerable<PatientResponseDto>>(patients);

        return Ok(patientDtos);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] PatientRequestDto patientDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var patient = _mapper.Map<Patient>(patientDto);

        await _patientServices.AddAsync(patient);

        return Ok();
    }

    [HttpPut("Edit/{id}")]
    public async Task<IActionResult> Edit(Guid id, [FromBody] PatientRequestDto patientDto)
    {
        var patient = await _patientServices.GetAsync(id);

        if (patient is null)
            return NotFound();

        patient = _mapper.Map(patientDto, patient);

        await _patientServices.UpdateAsync(patient);

        return NoContent();
    }

    [HttpDelete("Remove/{id}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        var patient = await _patientServices.GetAsync(id);

        if (patient is null)
            return NotFound();

        await _patientServices.DeleteAsync(patient);

        return NoContent();
    }
}
