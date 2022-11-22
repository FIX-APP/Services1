using FixAppAPI.App.Domain.Models;
using FixAppAPI.App.Domain.Repositories;
using FixAppAPI.App.Domain.Services;
using FixAppAPI.App.Domain.Services.Communication;
using FixAppAPI.App.Persistence.Repositories;
using FixAppAPI.Shared.Domain.Repositories;

namespace FixAppAPI.App.Services;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public AppointmentService(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _appointmentRepository = appointmentRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<Appointment>> ListAsync()
    {
        return await _appointmentRepository.ListAsync();
    }

    public async Task<IEnumerable<Appointment>> ListByUserIdAsync(int userId)
    {
        return await _appointmentRepository.FindByUserIdAsync(userId);
    }
    public async Task<IEnumerable<Appointment>> ListByTechnicianIdAsync(int technicianId)
    {
        return await _appointmentRepository.FindByTechnicianIdAsync(technicianId);
    }
    public async Task<AppointmentResponse> SaveAsync(Appointment appointment)
    {
        // Validate UserId

        var existingUser = await _userRepository.FindByIdAsync(appointment.userId);

        if (existingUser == null)
            return new AppointmentResponse("Invalid User");
        // Validate TechnicianId

        var existingTech = await _userRepository.FindByIdAsync(appointment.technicianId);

        if (existingTech == null)
            return new AppointmentResponse("Invalid Technician");

        try
        {
            // Add Appointment
            await _appointmentRepository.AddAsync(appointment);
            
            // Complete Transaction
            await _unitOfWork.CompleteAsync();
            
            // Return response
            return new AppointmentResponse(appointment);

        }
        catch (Exception e)
        {
            // Error Handling
            return new AppointmentResponse($"An error occurred while saving the appointment: {e.Message}");
        }

        
    }

    public async Task<AppointmentResponse> UpdateAsync(int appointmentId, Appointment appointment)
    {
        var existingAppointment = await _appointmentRepository.FindByIdAsync(appointmentId);

        // Validate Appointment

        if (existingAppointment == null)
            return new AppointmentResponse("Appointment not found.");

        // Validate UserId

        var existingCategory = await _userRepository.FindByIdAsync(appointment.userId);

        if (existingCategory == null)
            return new AppointmentResponse("Invalid User");
        // Validate TechId

        var existingTech = await _userRepository.FindByIdAsync(appointment.technicianId);

        if (existingTech == null)
            return new AppointmentResponse("Invalid Technician");

        // Modify Fields
        existingAppointment.technicianId = appointment.technicianId;
        try
        {
            _appointmentRepository.Update(existingAppointment);
            await _unitOfWork.CompleteAsync();

            return new AppointmentResponse(existingAppointment);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new AppointmentResponse($"An error occurred while updating the appointment: {e.Message}");
        }

    }

    public async Task<AppointmentResponse> DeleteAsync(int appointmentId)
    {
        var existingAppointment = await _appointmentRepository.FindByIdAsync(appointmentId);
        
        // Validate Tutorial

        if (existingAppointment == null)
            return new AppointmentResponse("Appointment not found.");
        
        try
        {
            _appointmentRepository.Remove(existingAppointment);
            await _unitOfWork.CompleteAsync();

            return new AppointmentResponse(existingAppointment);
            
        }
        catch (Exception e)
        {
            // Error Handling
            return new AppointmentResponse($"An error occurred while deleting the Appointment: {e.Message}");
        }

    }
}