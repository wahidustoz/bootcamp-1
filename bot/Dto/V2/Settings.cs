using System.Text.Json.Serialization;

namespace bot.Dto.V2
{
    public class Settings
    {
        [JsonPropertyName("timeformat")]
        public string Timeformat { get; set; }

        [JsonPropertyName("school")]
        public string School { get; set; }

        [JsonPropertyName("juristic")]
        public string Juristic { get; set; }

        [JsonPropertyName("highlat")]
        public string Highlat { get; set; }

        [JsonPropertyName("fajr_angle")]
        public double FajrAngle { get; set; }

        [JsonPropertyName("isha_angle")]
        public double IshaAngle { get; set; }
    }


}