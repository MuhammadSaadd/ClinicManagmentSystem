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

        var dto = _mapper.Map<ShiftDto>(shift);

        return Ok(dto);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var shifts = await _shiftServices.GetAllAsync();

        var shiftsDto = _mapper.Map<IEnumerable<ShiftDto>>(shifts);

        return Ok(shiftsDto);
    }

    [HttpPost("Book")]
    public async Task<IActionResult> Book([FromBody] ShiftDto shiftDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // المفروض دلوقتي هنحجز شيفت المفروض اربط الشيفت بالدكتور والعيادة-- اللي هيحجز الشيفت الدكتور
        // يعني المفروض اخد الايدي بتاعه وايدي العيادة اللي هيحجز فيها

        var clinic = await _clinicsServices.GetAsync(shiftDto.ClinicId);

        if (clinic is null)
            return BadRequest("Clinic is not existed");
        
        if(clinic.Availiable == false)
            return BadRequest("Clinic is not Availiable");



        return Ok();
    }
}
