using System.ComponentModel.DataAnnotations;
namespace FixAppAPI.App.Resources;

public class SaveAppointmentResource
{
    [Required]
    public int userId { get; set; }
    [Required]
    public int technicianId { get; set; }
}
