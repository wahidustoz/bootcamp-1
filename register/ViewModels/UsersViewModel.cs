namespace register.ViewModels;

public class UsersViewModel
{
    public IEnumerable<UserViewModel> Users { get; set; }
    
    public int Page { get; set; }
    
    public int Pages { get; set; }
    
    public int TotalUsers { get; set; }

    public int Limit { get; set; }
}