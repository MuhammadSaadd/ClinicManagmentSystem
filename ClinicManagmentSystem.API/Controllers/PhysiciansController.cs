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
        var physicianDto = await _physicianServices.GetAsync(id);

        if (physicianDto is null)
            return NotFound();;

        return Ok(physicianDto);
    }

    [HttpGet("GetBySSN/{ssn}")]
    public async Task<IActionResult> GetBySSN(string ssn)
    {
        var physicianDto = await _physicianServices.GetBySSNAsync(ssn);

        if (physicianDto is null)
            return NotFound();

        return Ok(physicianDto);
    }


    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var physicianDtos = await _physicianServices.GetAsync();

        return Ok(physicianDtos);
    }

    [HttpGet("GetAll/{speciality}")]
    public async Task<IActionResult> GetAll(string speciality)
    {
        var physicianDtos = await _physicianServices.GetBySpecialtyAsync(speciality);

        return Ok(physicianDtos);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] PhysicianDto physicianDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (await _physicianServices.GetByEmailAsync(physicianDto.Email) is not null)
            return BadRequest("This Email already exists");

        physicianDto.Password = _authenticationService.EncodePassword(physicianDto.Password!);

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

        await _physicianServices.UpdateAsync(physicianDto);

        return NoContent();
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var physicianDto = await _physicianServices.GetAsync(id);

        if (physicianDto is null)
            return NotFound();

        await _physicianServices.DeleteAsync(physicianDto);

        return NoContent();
    }
}
