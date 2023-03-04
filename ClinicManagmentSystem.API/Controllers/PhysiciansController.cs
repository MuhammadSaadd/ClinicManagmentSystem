namespace ClinicManagmentSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PhysiciansController : ControllerBase
{
    private readonly IPhysicianServices _physicianServices;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    public PhysiciansController(IPhysicianServices physicianServices, IMapper mapper, IAuthenticationService authenticationService)
    {
        _physicianServices = physicianServices;
        _mapper = mapper;
        _authenticationService = authenticationService;
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var physician = await _physicianServices.GetAsync(id);

        if (physician is null)
            return NotFound();

        var dto = _mapper.Map<PhysicianDto>(physician);

        return Ok(dto);
    }

    [HttpGet("GetBySSN/{ssn}")]
    public async Task<IActionResult> GetBySSN(string ssn)
    {
        var physician = await _physicianServices.GetBySSNAsync(ssn);

        if (physician is null)
            return NotFound();

        var dto = _mapper.Map<PhysicianDto>(physician);

        return Ok(dto);
    }


    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var physicians = await _physicianServices.GetAsync();

        var physiciansDto = _mapper.Map<IEnumerable<PhysicianDto>>(physicians);

        return Ok(physiciansDto);
    }

    [HttpGet("GetAll/{speciality}")]
    public async Task<IActionResult> GetAll(string speciality)
    {
        var physicians = await _physicianServices.GetBySpecialtyAsync(speciality);

        var physiciansDto = _mapper.Map<IEnumerable<PhysicianDto>>(physicians);

        return Ok(physiciansDto);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] PhysicianDto physicianDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        physicianDto.Password = _authenticationService.EncodePassword(physicianDto.Password);

        var physician = _mapper.Map<Physician>(physicianDto);

        await _physicianServices.AddAsync(physician);

        return Ok();
    }

    [HttpPut("Edit/{id}")]
    public async Task<IActionResult> Edit(Guid id, [FromBody] PhysicianDto physicianDto)
    {
        var physician = await _physicianServices.GetAsync(id);

        if (physician is null)
            return NotFound();

        physicianDto.Id = id;

        physician = _mapper.Map(physicianDto, physician);

        await _physicianServices.UpdateAsync(physician);

        return NoContent();
    }

    [HttpDelete("Remove/{id}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        var physician = await _physicianServices.GetAsync(id);

        if (physician is null)
            return NotFound();

        await _physicianServices.DeleteAsync(physician);

        return NoContent();
    }
}
