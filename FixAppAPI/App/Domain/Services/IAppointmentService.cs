using FixAppAPI.App.Domain.Models;
using FixAppAPI.App.Domain.Services.Communication;

namespace FixAppAPI.App.Domain.Services;

public interface IAppointmentService
{
    Task<IEnumerable<Appointment>> ListAsync();
    Task<IEnumerable<Appointment>> ListByUserIdAsync(int userId);
    Task<IEnumerable<Appointment>> ListByTechnicianIdAsync(int Technician);
    Task<AppointmentResponse> SaveAsync(Appointment appointment);
    Task<AppointmentResponse> UpdateAsync(int appointmentId, Appointment appointment);
    Task<AppointmentResponse> DeleteAsync(int appointmentId);

}
