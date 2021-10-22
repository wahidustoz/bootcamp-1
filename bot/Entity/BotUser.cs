using System;
using System.ComponentModel.DataAnnotations;

namespace bot.Entity
{
    public class BotUser
    {
        [Key]
        public long ChatId { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Address { get; set; }

        [Obsolete("Used only for Entity binding.")]
        public BotUser(){ }

        public BotUser(long chatId, string username, string fullname, double longitude, double latitude, string address)
        {
            ChatId = chatId;
            Username = username;
            Fullname = fullname;
            Longitude = longitude;
            Latitude = latitude;
            Address = address;
        }
    }
}