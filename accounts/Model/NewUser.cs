using System.ComponentModel.DataAnnotations;

namespace accounts.Model
{
    public class NewUser
    {
        [Required]
        [MaxLength(20)]
        public string Firstname { get; set; }

        [MaxLength(20)]
        public string Middlename { get; set; }
        
        [Required]
        [MaxLength(20)]
        public string Lastname { get; set; }
        
        [Required]
        [Phone]
        public string Phone { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(16)]
        [MinLength(6)]
        public string Password { get; set; }
    }
}