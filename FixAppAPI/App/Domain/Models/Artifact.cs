namespace FixAppAPI.App.Domain.Models;

public class Artifact
{
    public int id { get; set; }
    public string name { get; set; }
    public string url { get; set; }
    //RelationShips
    public int userId { get; set; }
    public User user { get; set; }
}
