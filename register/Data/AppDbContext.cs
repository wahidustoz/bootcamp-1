using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace register.Data;

public class AppDbContext : IdentityDbContext<AppUser> 
{
    public AppDbContext (DbContextOptions<AppDbContext> options) : base (options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<AppUser>().HasIndex(i => i.PhoneNumber).IsUnique();
    }
}