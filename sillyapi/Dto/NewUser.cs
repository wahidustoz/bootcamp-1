using System;
using System.ComponentModel.DataAnnotations;

namespace sillyapi.Dto
{
    public class NewUser
    {
        [MaxLength(10)]
        public string Firstname { get; set; }

        [MaxLength(10)]
        public string Lastname  { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        public DateTimeOffset Birthdate { get; set; }
    }

}