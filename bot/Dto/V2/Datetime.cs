using System.Text.Json.Serialization;

namespace bot.Dto.V2
{
    public class Datetime
    {
        [JsonPropertyName("times")]
        public Times Times { get; set; }

        [JsonPropertyName("date")]
        public Date Date { get; set; }
    }


}