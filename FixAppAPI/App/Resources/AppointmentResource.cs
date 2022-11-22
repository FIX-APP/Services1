using FixAppAPI.App.Domain.Models;

namespace FixAppAPI.App.Resources;

public class AppointmentResource
{
    public int id { get; set; }
    public User user { get; set; }
    public User technician { get; set; }
}
