namespace pizza.Mappers;

public static class PizzaModelEntityMapper
{
    public static Entities.Pizza ToPizzaEntity(this Models.PizzaRequest pizza)
    {
        return new Pizza(
                title: pizza.Title,
                ingredients: string.Join(',', pizza.Ingredients)
        );
    }
}