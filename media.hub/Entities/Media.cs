using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace media.hub.entities;

public class Media
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string ContentType { get; set; }

    public double SizeInMb 
    {
        get => Data.Length / (double)(1024 * 1024);
    }
    
    [Required]
    [MaxLength(5 * 1024 * 1024)]
    public byte[] Data { get; set; }
}