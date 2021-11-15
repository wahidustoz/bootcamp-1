namespace pizza.Services;

public interface IPizzaService
{
    Task<List<Pizza>> QueryPizzasAsync();
    Task<Pizza> QueryPizzaAsync(Guid id);
    Task<(bool IsSuccess, Exception Exception, Pizza Pizza)> CreatePizzaAsync(Pizza pizza);
    Task<bool> PizzaExistsAsync(Guid id);
    Task<(bool IsSuccess, Exception Exception, Pizza Pizza)> UpdatePizzaAsync(Pizza pizza);
    Task<(bool IsSuccess, Exception Exception)> RemovePizzaAsync(Guid id);
}