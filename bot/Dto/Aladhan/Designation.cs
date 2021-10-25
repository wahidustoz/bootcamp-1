using System.Text.Json.Serialization;

namespace bot.Dto.Aladhan
{
    public class Designation
    {
        [JsonPropertyName("abbreviated")]
        public string Abbreviated { get; set; }

        [JsonPropertyName("expanded")]
        public string Expanded { get; set; }
    }
}