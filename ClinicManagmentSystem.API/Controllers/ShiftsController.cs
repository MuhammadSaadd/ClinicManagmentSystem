namespace ClinicManagmentSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShiftsController : ControllerBase
{
    private readonly IShiftServices _shiftServices;
    private readonly IClinicServices _clinicsServices;
    private readonly IPhysicianServices _physicianServices;
    private readonly IMapper _mapper;

    public ShiftsController(IShiftServices shiftServices, IMapper mapper, IClinicServices clinicsServices, IPhysicianServices physicianServices)
    {
        _shiftServices = shiftServices;
        _mapper = mapper;
        _clinicsServices = clinicsServices;
        _physicianServices = physicianServices;
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var shift = await _shiftServices.GetAsync(id);

        if (shift == null)
            return BadRequest();

        var dto = _mapper.Map<ShiftResponseDto>(shift);

        return Ok(dto);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var shifts = await _shiftServices.GetAllAsync();

        var shiftsDto = _mapper.Map<IEnumerable<ShiftResponseDto>>(shifts);

        return Ok(shiftsDto);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] ShiftRequestDto shiftDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // clinc Validations
        var clinic = await _clinicsServices.GetAsync(shiftDto.ClinicId);

        if (clinic is null)
            return BadRequest("Clinic is not existed");

        // physician validations
        var physician = await _physicianServices.GetAsync(shiftDto.PhysicianId);

        if (physician is null)
            return BadRequest("Physician is not existed");

        // shifts validations
        if (await _shiftServices.IsShiftAvailable(shiftDto) == false)
            return BadRequest("This Shift is not Available");

        // create shift
        var shift = _mapper.Map<Shift>(shiftDto);
        shift.Id = Guid.NewGuid();
        shift.Finished = false;

        // add shift 
        await _shiftServices.AddAsync(shift);

        // Mark Shift As Finished
        BackgroundJob.Schedule(() => _shiftServices.MarkShiftAsFinished(shift.Id), shift.EndTime);

        return Ok();
    }
}
