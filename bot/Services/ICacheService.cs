using System;
using System.Threading.Tasks;
using bot.Models;

namespace bot.Services
{
    public interface ICacheService
    {
        Task<(bool IsSuccess, PrayerTime prayerTime, Exception exception)> GetOrUpdatePrayerTimeAsync(long chatId, double longitude, double latitude);
    }
}