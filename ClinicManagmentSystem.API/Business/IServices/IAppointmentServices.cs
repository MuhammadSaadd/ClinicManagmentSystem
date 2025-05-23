﻿namespace ClinicManagmentSystem.API.Business.IServices;

public interface IAppointmentServices
{
    Task<Appointment?> GetAsync(Guid id);
    Task<IEnumerable<Appointment>> GetAllAsync();
    Task AddAsync(Appointment appointment);
    Task<bool> IsAppointmentAvailableAsync(AppointmentRequestDto appointmentDto);
    Task MarkAppointmentAsEpisodeVisitAsync(Guid id);
    Task CancelAppointmentAsync(Appointment appointment);
}
