namespace pizza.Services;

public class PizzaService : IPizzaService
{
    private readonly PizzaDbContext _context;

    public PizzaService(PizzaDbContext context)
    {
        _context = context;
    }

    public async Task<(bool IsSuccess, Exception Exception, Pizza Pizza)> CreatePizzaAsync(Pizza pizza)
    {
        if(await PizzaExistsAsync(pizza.Id))
        {
            return (false, new ArgumentException($"There is no Pizza with given ID: {pizza.Id}"), null);
        }

        try
        {
            await _context.Pizzas.AddAsync(pizza);
            await _context.SaveChangesAsync();

            return (true, null, pizza);
        }
        catch(Exception e)
        {
            return (false, e, null);
        }
    }

    public Task<bool> PizzaExistsAsync(Guid id)
        => _context.Pizzas
        .AnyAsync(p => p.Id == id);

    public Task<Pizza> QueryPizzaAsync(Guid id)
        => _context.Pizzas
        .AsNoTracking()
        .Where(p => p.Id == id)
        .FirstOrDefaultAsync();

    public Task<List<Pizza>> QueryPizzasAsync()
        => _context.Pizzas
        .AsNoTracking()
        .ToListAsync();

    public async Task<(bool IsSuccess, Exception Exception)> RemovePizzaAsync(Guid id)
    {
        if(!await PizzaExistsAsync(id))
        {
            return (false, new ArgumentException($"There is no Pizza with given ID: {id}"));
        }

        _context.Pizzas.Remove(await QueryPizzaAsync(id));
        await _context.SaveChangesAsync();

        return (true, null);
    }

    public async Task<(bool IsSuccess, Exception Exception, Pizza Pizza)> UpdatePizzaAsync(Pizza pizza)
    {
        if(!await PizzaExistsAsync(pizza.Id))
        {
            return (false, new ArgumentException($"There is no Pizza with given ID: {pizza.Id}"), null);
        }

        pizza.ModifiedAt = DateTimeOffset.UtcNow;

        _context.Pizzas.Update(pizza);
        await _context.SaveChangesAsync();

        return (true, null, pizza);
    }
}