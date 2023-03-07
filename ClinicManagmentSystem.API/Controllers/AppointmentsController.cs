namespace ClinicManagmentSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentServices _appointmentServices;
    private readonly IPhysicianServices _physicianServices;
    private readonly IPatientServices _patientServices;
    private readonly IMapper _mapper;

    public AppointmentsController(IAppointmentServices appointmentServices,
        IPhysicianServices physicianServices, IPatientServices patientServices, IMapper mapper)
    {
        _appointmentServices = appointmentServices;
        _physicianServices = physicianServices;
        _patientServices = patientServices;
        _mapper = mapper;
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var appointment = await _appointmentServices.GetAsync(id);

        if (appointment == null)
            return BadRequest();

        var dto = _mapper.Map<AppointmentResponseDto>(appointment);

        return Ok(dto);
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var appointments = await _appointmentServices.GetAllAsync();

        var appointmentDtos = _mapper.Map<IEnumerable<AppointmentResponseDto>>(appointments);

        return Ok(appointmentDtos);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] AppointmentRequestDto appointmentDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // patient Validations
        var patient = await _patientServices.GetAsync(appointmentDto.PatientId);

        if (patient is null)
            return BadRequest("Clinic is not existed");

        // physician validations
        var physician = await _physicianServices.GetAsync(appointmentDto.PhysicianId);

        if (physician is null)
            return BadRequest("Physician is not existed");

        // appointment validations
        if (await _appointmentServices.IsAppointmentAvailableAsync(appointmentDto) == false)
            return BadRequest("This appointment is not Available");

        // create appointment
        var appointment = _mapper.Map<Appointment>(appointmentDto);
        appointment.Id = Guid.NewGuid();
        appointment.EpisodeVisitFlag = false;
        appointment.Canceled = false;

        // add appointment
        await _appointmentServices.AddAsync(appointment);

        // Mark Appointment As EposideVisit
        BackgroundJob.Schedule(() =>
            _appointmentServices.MarkAppointmentAsEposideVisitAsync(appointment.Id), appointment.EndDate);

        // Add a record to EposideVisits table

        return Ok();
    }
}
