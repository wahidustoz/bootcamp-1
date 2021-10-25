using System.Text.Json.Serialization;

namespace bot.Dto.V2
{
    public class Date
    {
        [JsonPropertyName("timestamp")]
        public int Timestamp { get; set; }

        [JsonPropertyName("gregorian")]
        public string Gregorian { get; set; }

        [JsonPropertyName("hijri")]
        public string Hijri { get; set; }
    }


}