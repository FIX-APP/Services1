namespace FixAppAPI.App.Domain.Models;

public class User
{
    public int id { get; set; }
    public string name { get; set; }
    public string lastName { get; set; }
    public string cellphone { get; set; }
    public string password { get; set; }
    public string email { get; set; }
    public string address { get; set; }
    public string rol { get; set; }

    //relationship
    public IList<Artifact> Artifacts { get; set; }=new List<Artifact>();
    public IList<Appointment> Appointments { get; set; }=new List<Appointment>();
}
