using FixAppAPI.App.Domain.Models;
using FixAppAPI.App.Domain.Repositories;
using FixAppAPI.Shared.Persistence.Contexts;
using FixAppAPI.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
namespace FixAppAPI.App.Persistence.Repositories;

public class AppointmentRepository : BaseRepository, IAppointmentRepository
{
    public AppointmentRepository(AppDbContext context) : base(context)
    {

    }
    public async Task<IEnumerable<Appointment>> ListAsync()
    {
        return await _context.Appointments.Include(p=>p.user).Include(p=>p.technician).ToListAsync();
    }
    public async Task AddAsync(Appointment appointment)
    {
        await _context.Appointments.AddAsync(appointment);
    }
    public async Task<Appointment> FindByIdAsync(int id)
    {
        return await _context.Appointments.Include(p=>p.user).Include(p=>p.technician).FirstOrDefaultAsync(p=>p.id==id);
    }
    public async Task<IEnumerable<Appointment>> FindByUserIdAsync(int id)
    {
        return await _context.Appointments.Where(p => p.userId == id).Include(p => p.user).ToListAsync();
    }
    public async Task<IEnumerable<Appointment>> FindByTechnicianIdAsync(int id)
    {
        return await _context.Appointments.Where(p=>p.technicianId==id).Include(p=>p.technician).ToListAsync();
    }
    public void Update(Appointment appointment)
    {
        _context.Appointments.Update(appointment);
    }
    public void Remove(Appointment appointment)
    {
        _context.Appointments.Remove(appointment);
    }
}
