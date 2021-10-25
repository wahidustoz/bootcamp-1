using System.Threading.Tasks;
using System.Net.Http;
using bot.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using bot.Extensions;
using bot.Dto.V2;

namespace bot.HttpClients
{
    public class PrayerTimeClient : IPrayerTimeClient
    {
        private readonly HttpClient _client;
        private readonly ILogger<PrayerTimeClient> _logger;

        public PrayerTimeClient(HttpClient client, ILogger<PrayerTimeClient> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<(bool IsSuccess, PrayerTime prayerTime, Exception exception)> GetPrayerTimeAsync(double lon, double lat)
        {
            var query = $"/times/today.json?longitude={lon}&latitude={lat}";
            
            using var httpResponse = await _client.GetAsync(query);
            
            if(httpResponse.IsSuccessStatusCode)
            {
                var jsonString = await httpResponse.Content.ReadAsStringAsync();
                var dto = JsonSerializer.Deserialize<PrayerTimeDto>(jsonString);
                
                return (true, dto.ToPrayerTimeModel(), null);
            }

            return (false, null, new Exception(httpResponse.ReasonPhrase));
        }
    }
}