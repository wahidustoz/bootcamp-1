using System;
using System.Threading.Tasks;
using bot.HttpClients;
using bot.Models;
using Microsoft.Extensions.Caching.Memory;

namespace bot.Services
{
    public class PrayerTimeCacheService : ICacheService
    {
        private readonly IMemoryCache _memCache;
        private readonly IPrayerTimeClient _client;

        public PrayerTimeCacheService(
            IMemoryCache memCache,
            IPrayerTimeClient client)
        {
            _memCache = memCache;
            _client = client;
        }
        public async Task<(bool IsSuccess, PrayerTime prayerTime, Exception exception)> GetOrUpdatePrayerTimeAsync(long chatId, double longitude, double latitude)
        {
            var key = string.Format($"{chatId}:{longitude}:{latitude}");

            return await _memCache.GetOrCreateAsync(key, async entry => 
            {   
                var result = await _client.GetPrayerTimeAsync(longitude, latitude);
                var zone = result.prayerTime.Timezone;
                var zoneId = TimeZoneInfo.FindSystemTimeZoneById(zone);

                var expirationTime = TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse("23:59:59"), zoneId);
                entry.AbsoluteExpiration = expirationTime;
                
                return result;
            });
        }
    }
}