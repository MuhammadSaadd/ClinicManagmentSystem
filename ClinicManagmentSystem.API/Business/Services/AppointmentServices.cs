namespace ClinicManagmentSystem.API.Business.Services;

public class AppointmentServices : IAppointmentServices
{
    private readonly AppDBContext _context;

    public AppointmentServices(AppDBContext context)
    {
        _context = context;
    }

    public async Task<Appointment?> GetAsync(Guid id)
    {
        return await _context.Appointments.SingleOrDefaultAsync(app => app.Id == id);
    }

    public async Task<IEnumerable<Appointment>> GetAllAsync()
    {
        return await _context.Appointments.ToListAsync();
    }

    public async Task AddAsync(Appointment appointment)
    {
        await _context.Appointments.AddAsync(appointment);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsAppointmentAvailableAsync(AppointmentRequestDto appointmentDto)
    {
        var oldAppointments = await _context.Appointments
            .Where(oldAppointment => oldAppointment.Canceled == false)
            .Where(oldAppointment => oldAppointment.EpisodeVisitFlag == false)
            .Where(oldAppointment => oldAppointment.StartDate > appointmentDto.StartDate)
            .Where(oldAppointment => oldAppointment.StartDate < appointmentDto.EndDate)
            .ToListAsync();

        return !oldAppointments.Any();
    }

    public async Task MarkAppointmentAsEpisodeVisitAsync(Guid id)
    {
        var appointment = await _context.Appointments.SingleOrDefaultAsync(sh => sh.Id == id);

        appointment!.EpisodeVisitFlag = true;

        _context.Appointments.Update(appointment);

        await _context.SaveChangesAsync();
    }

    public async Task CancelAppointmentAsync(Appointment appointment)
    {               
        _context.Appointments.Update(appointment);

        await _context.SaveChangesAsync();
    }
}
