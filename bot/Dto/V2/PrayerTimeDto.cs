using System.Text.Json.Serialization;

namespace bot.Dto.V2
{
    public class PrayerTimeDto
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("results")]
        public Results Results { get; set; }
    }


}