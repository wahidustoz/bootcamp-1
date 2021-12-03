using api.Entities;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostService _pService;
    private readonly IMediaService _mService;
    private readonly ILogger<PostController> _logger;

    public PostController(
        IPostService postService, 
        IMediaService mediaService,
        ILogger<PostController> logger)
    {
        _pService = postService;
        _mService = mediaService;
        _logger = logger;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreatePostAsync([FromBody]PostModel model)
    {
        if(model.MediaIds.Count() > 0 && !model.MediaIds.All(m => _mService.MediaExistsAsync(m).Result))
        {
            return BadRequest("Given Media IDs do not exist");
        }

        var medias = model.MediaIds
            .Select(m => _mService.GetMediaByIdAsync(m).Result)
            .ToList();
        
        var post = new Post(
            title: model.Title, 
            description: model.Description, 
            content: model.Content,
            headerImageId: model.HeaderImageId,
            medias: medias);
        
        var result = await _pService.InsertPostAsync(post);

        if(result.IsSuccess)
        {
            return Ok(new
            {
                Id = post.Id,
                Title = post.Title,
                Description = post.Description
            });
        }

        return BadRequest(result.Exception.Message);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostAsync([FromRoute]Guid id)
    {
        var post = await _pService.GetPostByIdAsync(id);

        if(post == default)
        {
            return NotFound();
        }

        post.Viewed++;
        await _pService.UpdatePostAsync(post);

        return Ok(new
        {
            Id = post.Id,
            HeaderImageUrl = post.HeaderImageId == default ? null : $"{Request.Scheme}://{Request.Host}/api/media/{post.HeaderImageId}",
            Title = post.Title,
            Description = post.Description,
            Content = post.Content,
            Viewed = post.Viewed,
            CreatedAt = post.CreatedAt,
            UpdateAt = post.ModifiedAt,
            Comments = post.Comments
        });
    }

    [HttpGet]
    public async Task<IActionResult> GetPostsAsync([FromQuery]int page = 1, [FromQuery]int limit = 10)
    {
        var posts = await _pService.GetPostsAsync(limit, (page - 1) * limit);

        if(posts == default || posts.Count() < 1)
        {
            return NotFound();
        }

        return Ok(posts.Select(p => new 
        {
            Id = p.Id,
            HeaderImageUrl = p.HeaderImageId == default ? null : $"{Request.Scheme}://{Request.Host}/api/media/{p.HeaderImageId}",
            Title = p.Title,
            Description = p.Description,
            Viewed = p.Viewed,
            CreatedAt = p.CreatedAt,
        }));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemovePostAsync([FromRoute]Guid id)
    {
        if(!await _pService.PostExistsAsync(id))
        {
            return BadRequest();
        }

        var post = await _pService.GetPostByIdAsync(id);
        var result = await _pService.DeletePostAsync(post);

        if(result.IsSuccess)
        {
            return Ok();
        }

        return BadRequest(result.Exception.Message);
    }
}