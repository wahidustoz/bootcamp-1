using intro.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace intro.Controllers;

[Route("")]
public class BlogsController : Controller
{
    private static List<PostViewModel> Blogs = new List<PostViewModel>();

    [HttpGet("blogs")]
    public IActionResult GetBlogs()
    {
        return View(new BlogsViewModel()
        {
            Blogs = new List<BlogViewModel>()
            {
                new BlogViewModel()
                {
                    Id = Guid.NewGuid(),
                    Title = "Introduction to Web3 with .NET",
                    Description = "In this post u will learn how to create web3 solutions using .NET 👀.",
                    Tags = new List<string>()
                    {
                        "dotnet", "web3", "ilmhub"
                    },
                    BannerImageUrl = "https://placekitten.com/200/250"
                },
                new BlogViewModel()
                {
                    Id = Guid.NewGuid(),
                    Title = "Advanced Pishak placeholder generation",
                    Description = "Pishak bu o'zbek tilining voxa shevasida mushuk 🐈 manosini anglatadi.",
                    Tags = new List<string>()
                    {
                        "pishak", "mushu", "mishiq", "cat", "koshka"
                    },
                    BannerImageUrl = "https://placekitten.com/200/250"
                }
            }
        });
    }

    [HttpGet("write")]
    public IActionResult Write()
    {
        return View();
    }

    [HttpPost("write")]
    public IActionResult Write([FromForm]PostViewModel model)
    {
        model.Edited = model.CreatedAt != default;
        model.CreatedAt = DateTimeOffset.UtcNow;
        model.Id = Guid.NewGuid();

        Blogs.Add(model);

        return LocalRedirect($"~/posts/{model.Id}");
    }

    [HttpGet("posts/{id}")]
    public IActionResult Posts(Guid id)
    {
        var model = Blogs.FirstOrDefault(p => p.Id == id);
        return View(model);
    }

    [HttpGet("edit/{id}")]
    public IActionResult Edit(Guid id)
    {
        var model = Blogs.FirstOrDefault(p => p.Id == id);

        return View("Write", model);
    }
}

public class PostViewModel
{
    public Guid Id { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    
    public string Title { get; set; }
    
    public string Content { get; set; }

    public bool Edited { get; set; }
    
}