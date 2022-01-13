using Microsoft.AspNetCore.Identity;

namespace intro.Entity;

public class User : IdentityUser
{
    public string Fullname { get; set; }

    public DateTimeOffset Birthdate { get; set; }

    public string Name { get; set; }
}