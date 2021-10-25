using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace bot.Dto.V2
{
    public class Results
    {
        [JsonPropertyName("datetime")]
        public List<Datetime> Datetime { get; set; }

        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("settings")]
        public Settings Settings { get; set; }
    }
}