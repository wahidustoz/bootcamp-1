namespace pizza.Data;

public class PizzaDbContext : DbContext
{
    public DbSet<Pizza> Pizzas { get; set; }
    
    public PizzaDbContext(DbContextOptions<PizzaDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Pizza>().HasIndex(p => p.ShortName).IsUnique();
    }
}