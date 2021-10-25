using System.Threading.Tasks;
using System.Net.Http;
using bot.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using bot.Dto.Aladhan;
using bot.Extensions;

namespace bot.HttpClients
{
    public class AladhanClient : IPrayerTimeClient
    {
        private readonly HttpClient _client;
        private readonly ILogger<AladhanClient> _logger;

        public AladhanClient(HttpClient client, ILogger<AladhanClient> logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task<(bool IsSuccess, PrayerTime prayerTime, Exception exception)> GetPrayerTimeAsync(double lon, double lat)
        {
            var query = $"/timings/{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}?longitude={lon}&latitude={lat}&method=14&school=1";
            
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