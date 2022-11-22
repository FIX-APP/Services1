using FixAppAPI.App.Domain.Models;
using FixAppAPI.Shared.Domain.Services.Communication;

namespace FixAppAPI.App.Domain.Services.Communication;

public class AppointmentResponse : BaseResponse<Appointment>
{
    public AppointmentResponse(string message) : base(message)
    {

    }
    public AppointmentResponse(Appointment resource) : base(resource)
    {

    }
}
