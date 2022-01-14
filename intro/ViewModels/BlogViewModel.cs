namespace intro.ViewModels;

public class BlogViewModel
{
    public Guid Id { get; set; }
    public string BannerImageUrl { get; set; }
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public IEnumerable<string> Tags { get; set; }
}