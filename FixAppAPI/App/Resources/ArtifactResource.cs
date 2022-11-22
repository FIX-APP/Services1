using FixAppAPI.App.Domain.Models;

namespace FixAppAPI.App.Resources;

public class ArtifactResource
{
    public int id { get; set; }
    public string name { get; set; }
    public string url { get; set; }
    public User user { get; set; }
}
