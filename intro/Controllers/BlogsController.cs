using intro.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace intro.Controllers;

[Route("")]
public class BlogsController : Controller
{
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
}