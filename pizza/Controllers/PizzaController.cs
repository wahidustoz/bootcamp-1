using Microsoft.AspNetCore.Mvc;

namespace pizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private readonly ILogger<PizzaController> _logger;
    private readonly IPizzaService _pizzaService;

    public PizzaController(ILogger<PizzaController> logger, IPizzaService pizzaService)
    {
        _logger = logger;
        _pizzaService = pizzaService;
    }

    [HttpPost]
    public async Task<IActionResult> PostPizza(Models.PizzaRequest pizza)
    {
        return CreatedAtAction(nameof(PostPizza), await _pizzaService.CreatePizzaAsync(pizza.ToPizzaEntity()));
    }
}