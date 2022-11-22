using AutoMapper;
using FixAppAPI.App.Domain.Models;
using FixAppAPI.App.Domain.Services;
using FixAppAPI.App.Resources;
using FixAppAPI.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace FixAppAPI.App.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;
    private readonly IMapper _mapper;

    public AppointmentsController(IAppointmentService appointmentService, IMapper mapper)
    {
        _appointmentService = appointmentService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<AppointmentResource>> GetAllAsync()
    {
        var appointments = await _appointmentService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Appointment>, IEnumerable<AppointmentResource>>(appointments);

        return resources;

    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveAppointmentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var appointment = _mapper.Map<SaveAppointmentResource, Appointment>(resource);

        var result = await _appointmentService.SaveAsync(appointment);

        if (!result.Success)
            return BadRequest(result.Message);

        var appointmentResource = _mapper.Map<Appointment, AppointmentResource>(result.Resource);

        return Ok(appointmentResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveAppointmentResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var appointment = _mapper.Map<SaveAppointmentResource, Appointment>(resource);

        var result = await _appointmentService.UpdateAsync(id, appointment);

        if (!result.Success)
            return BadRequest(result.Message);

        var appointmentResource = _mapper.Map<Appointment, AppointmentResource>(result.Resource);

        return Ok(appointmentResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _appointmentService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);

        var appointmentResource = _mapper.Map<Appointment, AppointmentResource>(result.Resource);

        return Ok(appointmentResource);
    }
    
}