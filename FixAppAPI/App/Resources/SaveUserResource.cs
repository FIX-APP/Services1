using System.ComponentModel.DataAnnotations;
namespace FixAppAPI.App.Resources;

public class SaveUserResource
{
    [Required]
    [MaxLength(15)]
    public string name { get; set; }

    [Required]
    [MaxLength(15)]
    public string lastName { get; set; }

    [Required]
    [MaxLength(9)]
    public string cellphone { get; set; }

    [Required]
    [MaxLength(20)]
    public string password { get; set; }

    [Required]
    [MaxLength(25)]
    public string email { get; set; }

    [Required]
    [MaxLength(30)]
    public string address { get; set; }

    [Required]
    [MaxLength(1)]
    public string rol { get; set; }


}
