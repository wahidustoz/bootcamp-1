using System.ComponentModel.DataAnnotations;

namespace accounts.Model
{
    public class UpdatedUser
    {
        [MaxLength(20)]
        public string Firstname { get; set; }

        [MaxLength(20)]
        public string Middlename { get; set; }
        
        [MaxLength(20)]
        public string Lastname { get; set; }
        
        [Phone]
        public string Phone { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        
        [MaxLength(16)]
        [MinLength(6)]
        public string Password { get; set; }

        [MaxLength(16)]
        public string Username { get; set; }
    }
}