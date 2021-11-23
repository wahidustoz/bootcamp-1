namespace media.hub.models;

public class AdModel
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public List<string> Tags { get; set; }

    public IEnumerable<IFormFile> Files { get; set; }
}