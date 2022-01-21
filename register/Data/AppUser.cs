using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace register.Data;

public class AppUser : IdentityUser
{
    [Required]
    [MaxLength(64)]
    public string Fullname { get; set; }

    [Required]
    public DateTimeOffset Birthdate { get; set; }

    // [ForeignKey("AspNetRoles")]
    // public virtual ICollection<IdentityRole> Roles { get; set; }
}