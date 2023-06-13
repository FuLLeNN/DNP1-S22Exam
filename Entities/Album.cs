using System.ComponentModel.DataAnnotations;

namespace Entities;

public class Album
{
    [Key]
    [Required]
    [MaxLength(25)]
    public string title { get; set; }
    [Required]
    [MaxLength(150)]
    public string description { get; set; }
    [Required]
    public string createdBy { get; set; }
}