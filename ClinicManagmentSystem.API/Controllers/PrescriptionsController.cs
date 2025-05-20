namespace ClinicManagmentSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrescriptionsController : ControllerBase
{
    private readonly IPrescriptionServices _prescriptionServices;
    private readonly IMapper _mapper;

    public PrescriptionsController(IMapper mapper, IPrescriptionServices prescriptionServices)
    {
        _mapper = mapper;
        _prescriptionServices = prescriptionServices;
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var prescription = await _prescriptionServices.GetAsync(id);

        if (prescription is null)
            return NotFound();

        var dto = _mapper.Map<PrescriptionDto>(prescription);

        return Ok(dto);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var prescriptions = await _prescriptionServices.GetAsync();

        var prescriptionDtos = _mapper.Map<IEnumerable<PrescriptionDto>>(prescriptions);

        return Ok(prescriptionDtos);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] PrescriptionDto prescriptionDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var prescription = _mapper.Map<Prescription>(prescriptionDto);

        await _prescriptionServices.CreateAsync(prescription);

        return Ok();
    }

    [HttpPut("Edit/{id}")]
    public async Task<IActionResult> Edit(string id, [FromBody] PrescriptionDto prescriptionDto)
    {
        var prescription = await _prescriptionServices.GetAsync(id);

        if (prescription is null)
            return NotFound();

        prescription = _mapper.Map(prescriptionDto, prescription);

        await _prescriptionServices.UpdateAsync(id, prescription);

        return NoContent();
    }

    [HttpDelete("Remove/{id}")]
    public async Task<IActionResult> Remove(string id)
    {
        var prescription = await _prescriptionServices.GetAsync(id);

        if (prescription is null)
            return NotFound();

        await _prescriptionServices.DeleteAsync(id);

        return NoContent();
    }
}
