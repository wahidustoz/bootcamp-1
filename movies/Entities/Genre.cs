using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace movies.Entities;

public class Genre
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string Name { get; set; }
    
    public ICollection<Movie> Movies { get; set; }
}