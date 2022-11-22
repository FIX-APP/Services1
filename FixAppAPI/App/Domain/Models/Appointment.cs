namespace FixAppAPI.App.Domain.Models;

public class Appointment
{
    public int id { get; set; } 
    //relationShip
    public int userId { get; set; } 
    public User user { get; set; }    
    public int technicianId { get; set; }   
    public User technician { get; set; }    
}
