using System.Text.Json.Serialization;

namespace bot.Dto.Aladhan
{

    public class PrayerTimeDto
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }
}