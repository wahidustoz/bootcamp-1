using System.Text.Json.Serialization;

namespace pizza.Models;

public class PizzaRequest
{
    [Required]
    [MaxLength(255)]
    public string Title { get; set; }

    [Required]
    [MaxLength(255)]
    public List<string> Ingredients { get; set; }

    [Required]
    [MaxLength(3)]
    [MinLength(3)]
    public string ShortName { get; set; }

    [Range(1, double.MaxValue)]
    public double Price { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public EStockStatus Status { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset ModifiedAt { get; set; }
}