using Microsoft.EntityFrameworkCore;

namespace bot.Entity
{
    public class BotDbContext : DbContext
    {
        public DbSet<BotUser> Users { get; set; }

        public BotDbContext(DbContextOptions<BotDbContext> options)
            :base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
        }
    }
}