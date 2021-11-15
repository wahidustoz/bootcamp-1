namespace pizza.Entities;

public class Pizza
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Title { get; set; }

    [Required]
    [MaxLength(255)]
    public string Ingredients { get; set; }

    [Required]
    [MaxLength(3)]
    [MinLength(3)]
    public string ShortName { get; set; }

    [Range(1, double.MaxValue)]
    public double Price { get; set; }

    public EStockStatus Status { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset ModifiedAt { get; set; }

    [Obsolete("Used only for entity binding.", true)]
    public Pizza() { }

    public Pizza(string title, string ingredients, string shortName, double price, EStockStatus status)
    {
        Id = Guid.NewGuid();
        Title = title;
        Ingredients = ingredients;
        ShortName = shortName;
        Price = price;
        Status = status;
        CreatedAt = DateTimeOffset.UtcNow;
        ModifiedAt = CreatedAt;
    }
}