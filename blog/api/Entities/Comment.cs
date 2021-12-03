using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api.Entities;

public class Comment : EntityBase
{
    [Required]
    [MaxLength(1024)]
    public string Content { get; set; }

    [ForeignKey("Posts")]
    public Guid PostId { get; set; }

    [Required]
    public DateTimeOffset CreatedAt { get; set; }
    
    [Required]
    public DateTimeOffset ModifiedAt { get; set; }

    public Comment(string content, Guid postId)
    {
        Content = content;
        PostId = postId;

        CreatedAt = DateTimeOffset.UtcNow;
        ModifiedAt = DateTimeOffset.UtcNow;
    }
}