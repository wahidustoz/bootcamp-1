using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace movies.Entities;

public class Image
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }
    
    [Required]
    [MinLength(1)]
    [MaxLength(5242880)]
    public byte[] Data { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string ContentType { get; set; }
    
    [MaxLength(255)]
    public string AltText { get; set; }
    
    [Required]
    [ForeignKey("Movies")]
    public Guid MovieId { get; set; }
}