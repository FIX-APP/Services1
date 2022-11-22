using FixAppAPI.App.Domain.Models;

namespace FixAppAPI.App.Domain.Repositories;

public interface IAppointmentRepository
{
    Task<IEnumerable<Appointment>> ListAsync();
    Task AddAsync(Appointment appointment);
    Task<Appointment> FindByIdAsync(int appointmentId);
    Task<IEnumerable<Appointment>> FindByUserIdAsync(int userId);
    Task<IEnumerable<Appointment>> FindByTechnicianIdAsync(int technicianId);
    void Update(Appointment appointment);
    void Remove(Appointment appointment);
}
