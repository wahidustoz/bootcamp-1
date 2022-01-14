using intro.Data;
using intro.Entity;
using intro.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace intro.Controllers;

[Route("")]
public class BlogsController : Controller
{
    private readonly ILogger<BlogsController> _logger;
    private readonly BlogAppDbContext _context;
    private readonly UserManager<User> _userM;

    public BlogsController(
        ILogger<BlogsController> logger,
        BlogAppDbContext context,
        UserManager<User> userManager)
    {
        _logger = logger;
        _context = context;
        _userM = userManager;
    }

    [HttpGet("blogs")]
    public async Task<IActionResult> GetBlogs()
    {
        return View(new BlogsViewModel()
        {
            Blogs = await _context.Posts.Select(p => new BlogViewModel()
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Content
            })
            .ToListAsync()
        });
    }

    [Authorize]
    [HttpGet("write")]
    public IActionResult Write()
    {
        return View();
    }

    [Authorize]
    [HttpPost("write")]
    public async Task<IActionResult> Write([FromForm]PostViewModel model)
    {
        if(!ModelState.IsValid)
        {
            return BadRequest($"{ModelState.ErrorCount} errors detected!");
        }

        if(model.Edited)
        {
            var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == model.Id);
            if(post.Title == model.Title && post.Content == model.Content)
            {
                return LocalRedirect($"~/post/{post.Id}");
            }

            post.ModifiedAt = DateTimeOffset.UtcNow;
            post.Title = model.Title;
            post.Content = model.Content;

            _context.Posts.Update(post);
            await _context.SaveChangesAsync();

            return LocalRedirect($"~/post/{post.Id}");
        }

        var userId = _userM.GetUserId(User);
        var newPost = new Post(model.Title, model.Content, Guid.Parse(userId));

        _context.Posts.Add(newPost);
        await _context.SaveChangesAsync();

        return LocalRedirect($"~/post/{newPost.Id}");
    }

    [HttpGet("post/{id}")]
    public async Task<IActionResult> Post(Guid id)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        var model = new PostViewModel()
        {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content,
            Edited = post.Edited,
            Claps = post.Claps,
            CreatedAt = post.CreatedAt
        };
    
        return View(model);
    }

    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit(Guid id)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);
        var model = new PostViewModel()
        {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content,
            Edited = true,
            Claps = post.Claps,
            CreatedAt = post.CreatedAt
        };

        return View("Write", model);
    }
}