namespace FixAppAPI.App.Controllers;
using AutoMapper;
using FixAppAPI.App.Domain.Models;
using FixAppAPI.App.Domain.Services;
using FixAppAPI.App.Resources;
using FixAppAPI.App.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/v1/users/{userId}/appointments")]
public class UserAppointmentController 
{
    private readonly IAppointmentService _appointmentService;
    private readonly IMapper _mapper;
    public UserAppointmentController(IAppointmentService appointmentService, IMapper mapper)
    {
        _appointmentService = appointmentService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IEnumerable<AppointmentResource>> GetAllByCategoryIdAsync(int userId)
    {
        var appoitments = await _appointmentService.ListByUserIdAsync(userId);

        var resources = _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentResource>>(appoitments);

        return resources;
    }
}


