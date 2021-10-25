using System;
using System.Threading.Tasks;
using bot.Models;

namespace bot.HttpClients
{
    public interface IPrayerTimeClient
    {
        Task<(bool IsSuccess, PrayerTime prayerTime, Exception exception)> GetPrayerTimeAsync(double longitude, double latitude);
    }
}