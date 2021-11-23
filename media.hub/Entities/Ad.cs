using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace media.hub.entities;

public class Ad
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Title { get; set; }
    
    [Required]
    [MaxLength(1024)]
    public string Description { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Tags { get; set; }
    
    public ICollection<Media> Medias { get; set; }
}