using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class Image
{
    [Key] 
    public int id { get; set; }
    [Required]
    [MaxLength(25)]
    public string title { get; set; }
    public string description { get; set; }
    [Required]
    public string url { get; set; }
    [Required]
    public string topic { get; set; }
    
    [ForeignKey("Album")]
    public string album_title { get; set; }
}