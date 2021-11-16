namespace pizza.Mappers;

public static class PizzaModelEntityMapper
{
    public static Entities.Pizza ToPizzaEntity(this Models.PizzaRequest pizza)
    {
        return new Pizza(
            title: pizza.Title,
            ingredients: string.Join(',', pizza.Ingredients),
            shortName: pizza.ShortName,
            price: pizza.Price,
            status: pizza.Status.ToEntityStockStatus());
    }

    public static Entities.EStockStatus ToEntityStockStatus(this Models.EStockStatus status)
        => status switch
        {
            Models.EStockStatus.IN => Entities.EStockStatus.IN,
            _ => Entities.EStockStatus.OUT
        };
}