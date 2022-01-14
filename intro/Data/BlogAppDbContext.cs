using intro.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace intro.Data;

public class BlogAppDbContext : IdentityDbContext<User>
{
    public DbSet<Post> Posts { get; set; }
    
    public BlogAppDbContext(DbContextOptions<BlogAppDbContext> options)
        : base(options) { }
}