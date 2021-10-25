using System.Text.Json.Serialization;

namespace bot.Dto.Aladhan
{
    public class Params
    {
        [JsonPropertyName("Fajr")]
        public int Fajr { get; set; }

        [JsonPropertyName("Isha")]
        public int Isha { get; set; }
    }
}