using bot.Models;

namespace bot.Extensions
{
    public static class PrayerTimeExtensions
    {
        public static PrayerTime ToPrayerTimeModel(this Dto.Aladhan.PrayerTimeDto dto)
        {
            return new PrayerTime()
            {
                Fajr = dto.Data.Timings.Fajr,
                Dhuhr = dto.Data.Timings.Dhuhr,
                Sunrise = dto.Data.Timings.Sunrise,
                Asr = dto.Data.Timings.Asr,
                Maghrib = dto.Data.Timings.Maghrib,
                Isha = dto.Data.Timings.Isha,
                Sunset = dto.Data.Timings.Sunset,
                Midnight = dto.Data.Timings.Midnight,
                Source = "aladhan.com",
                CalculationMethod = dto.Data.Meta.Method.Name,
                Timezone = dto.Data.Meta.Timezone
            };
        }
    
        public static PrayerTime ToPrayerTimeModel(this Dto.V2.PrayerTimeDto dto)
        {
            return new PrayerTime()
            {
                Fajr = dto.Results.Datetime[0].Times.Fajr,
                Sunrise = dto.Results.Datetime[0].Times.Sunrise,
                Sunset = dto.Results.Datetime[0].Times.Sunset,
                Dhuhr = dto.Results.Datetime[0].Times.Dhuhr,
                Asr = dto.Results.Datetime[0].Times.Asr,
                Maghrib = dto.Results.Datetime[0].Times.Maghrib,
                Isha = dto.Results.Datetime[0].Times.Isha,
                Midnight = dto.Results.Datetime[0].Times.Midnight,
                Source = "prayertimes.date",
                CalculationMethod = dto.Results.Settings.School
            };
        }
    
    }
}