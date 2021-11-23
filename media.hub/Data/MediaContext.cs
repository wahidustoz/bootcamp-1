using media.hub.entities;
using Microsoft.EntityFrameworkCore;

namespace media.hub.data;

public class MediaContext : DbContext
{
    public DbSet<Ad> Ads { get; set; }
    
    public DbSet<Media> Medias { get; set; }
    
    
    public MediaContext(DbContextOptions options)
        : base(options) { }
}