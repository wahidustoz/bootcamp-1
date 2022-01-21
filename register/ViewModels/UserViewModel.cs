namespace register.ViewModels;

public class UserViewModel
{
    public string Fullname { get; set; }
    
    public string Email { get; set; }
    
    public string Username { get; set; }
    
    public string Phone { get; set; }
    
    public DateTimeOffset Birthdate { get; set; }
}