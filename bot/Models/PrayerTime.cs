namespace bot.Models
{
    public class PrayerTime
    {
        public string Fajr { get; set; }
        public string Sunrise { get; set; }
        public string Dhuhr { get; set; }
        public string Asr { get; set; }
        public string Isha { get; set; }
        public string Sunset { get; set; }
        public string Maghrib { get; set; }
        public string Midnight { get; set; }
        public string Source { get; set; }
        public string CalculationMethod { get; set; }
        public string Timezone { get; set; }
    }
}