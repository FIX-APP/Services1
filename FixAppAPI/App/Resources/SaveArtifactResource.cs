
using System.ComponentModel.DataAnnotations;
namespace FixAppAPI.App.Resources;

public class SaveArtifactResource
{
    [Required]
    [MaxLength(20)]
    public string name { get; set; }

    [Required]
    public string url { get; set; }

    [Required]
    public int userId { get; set; }

}
