namespace ClinicManagmentSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentServices _appointmentServices;
    private readonly IPhysicianServices _physicianServices;
    private readonly IPatientServices _patientServices;
    private readonly IEpisodeVisitServices _episodeVisitServices;
    private readonly IEpisodeVisitJobServices _episodeVisitJobServices;
    private readonly IMapper _mapper;

    public AppointmentsController(IAppointmentServices appointmentServices,
        IPhysicianServices physicianServices, IPatientServices patientServices, IMapper mapper,
        IEpisodeVisitServices episodeVisitServices, IEpisodeVisitJobServices episodeVisitJobServices)
    {
        _appointmentServices = appointmentServices;
        _physicianServices = physicianServices;
        _patientServices = patientServices;
        _episodeVisitServices = episodeVisitServices;
        _episodeVisitJobServices = episodeVisitJobServices;
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

        // Mark Appointment As EpisodeVisit
        string appointmentJobId = BackgroundJob.Schedule(() =>
            _appointmentServices.MarkAppointmentAsEpisodeVisitAsync(appointment.Id), appointment.EndDate);

        appointment.JopId = appointmentJobId;

        // add appointment
        await _appointmentServices.AddAsync(appointment);

        // Add a record to episodeVisits table      
        string episodeVisitJobId = BackgroundJob.Schedule(() =>
            _episodeVisitServices.AddAsync(appointment.Id), appointment.EndDate);


        // add episode Visit Job
        var episodeVisitJob = new EpisodeVisitJob
        {
            EpisodeVisitJobId = episodeVisitJobId,
            AppointmentJobId = appointment.JopId
        };

        await _episodeVisitJobServices.AddAsync(episodeVisitJob);

        return Ok();
    }


    [HttpPut("Cancel")]
    public async Task<IActionResult> Cancel(Guid id)
    {
        var appointment = await _appointmentServices.GetAsync(id);

        if (appointment is null)
            return NotFound();

        appointment.Canceled = true;

        await _appointmentServices.CancelAppointmentAsync(appointment);

        // delete appointment from hangfire queue
        BackgroundJob.Delete(appointment.JopId);

        // delete episode Visit Job from hangfire queue
        var episodeVisitJob = await _episodeVisitJobServices.GetAsync(appointment.JopId);

        if (episodeVisitJob is not null)
        {
            BackgroundJob.Delete(episodeVisitJob.EpisodeVisitJobId);

            await _episodeVisitJobServices.DeleteAsync(episodeVisitJob);
        }

        return NoContent();
    }
}
