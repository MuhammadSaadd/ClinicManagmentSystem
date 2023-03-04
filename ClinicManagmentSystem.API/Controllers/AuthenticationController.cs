namespace ClinicManagmentSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IPhysicianServices _physicianServices;
    private readonly IMapper _mapper;

    public AuthenticationController(IAuthenticationService authenticationService, IPhysicianServices physicianServices, IMapper mapper)
    {
        _authenticationService = authenticationService;
        _physicianServices = physicianServices;
        _mapper = mapper;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(PhysicianDto physicianDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        physicianDto.Password = _authenticationService.EncodePassword(physicianDto.Password);

        var physician = _mapper.Map<Physician>(physicianDto);

        await _physicianServices.AddAsync(physician);

        return Ok();
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var physician = await _physicianServices.GetByEmailAsync(loginDto.Email);

        if (physician is null)
            return NotFound();

        if(_authenticationService.VerifyPassword(loginDto.Password, physician.Password) == false)
            return BadRequest("Password is not correct");

        return Ok();
    }
}
