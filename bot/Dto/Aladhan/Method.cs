using System.Text.Json.Serialization;

namespace bot.Dto.Aladhan
{
    public class Method
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("params")]
        public Params Params { get; set; }
    }
}