namespace ClinicManagmentSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationServices;
    private readonly IPhysicianServices _physicianServices;
    private readonly IMailingService _mailingServices;
    private readonly IMapper _mapper;

    public AuthenticationController(IAuthenticationService authenticationServices
        , IPhysicianServices physicianServices, IMapper mapper, IMailingService mailingServices)
    {
        _authenticationServices = authenticationServices;
        _physicianServices = physicianServices;
        _mapper = mapper;
        _mailingServices = mailingServices;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] PhysicianRequestDto physicianDto)
    {
        string subject = "Registeration is Complete!";
        string body = $"Hi Dr. {physicianDto.FirstName} {physicianDto.LastName}," +
            $"Thank you for registering with our system. " +
            $"We are excited to have you as a part of our community and look forward to" +
            $" providing you with an exceptional user experience.";

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (await _physicianServices.GetByEmailAsync(physicianDto.Email) is not null)
            return BadRequest("This Email already exists");

        physicianDto.Password = _authenticationServices.EncodePassword(physicianDto.Password!);

        var physician = _mapper.Map<Physician>(physicianDto);

        physician.Id = Guid.NewGuid();

        await _physicianServices.AddAsync(physician);

        await _mailingServices
            .SendEmailAsync(physician.Email, subject, body);

        return Ok();
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var physician = await _physicianServices.GetByEmailAsync(loginDto.Email);

        if (physician is null)
            return NotFound();

        if (_authenticationServices.VerifyPassword(loginDto.Password, physician.Password!) == false)
            return BadRequest("Password is not correct");

        return Ok();
    }
}
