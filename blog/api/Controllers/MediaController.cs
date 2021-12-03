using api.Entities;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService _mService;
        private readonly ILogger<MediaController> _logger;

        public MediaController(IMediaService mediaService, ILogger<MediaController> logger)
        {
            _mService = mediaService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMediaAsync([FromForm]MediaModel media)
        {
            using var mediaStream = new MemoryStream();
            await media.File.CopyToAsync(mediaStream);
            var entity = new Media(
                media.AltText, 
                mediaStream.ToArray(), 
                media.File.ContentType);
            
            var result = await _mService.InsertMediaAsync(entity);

            if(!result.IsSuccess)
            {
                return BadRequest(result.Exception.Message);
            }

            return CreatedAtAction("CreateMedia", new 
            {
                Id = entity.Id,
                AltText = entity.AltText,
                Url = $"{Request.Scheme}://{Request.Headers.Host}/api/media/{entity.Id}"
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMediaAsync([FromRoute]Guid id)
        {
            if(await _mService.MediaExistsAsync(id))
            {
                var media = await _mService.GetMediaByIdAsync(id);

                return File(media.Data, media.ContentType);
            }
            else
            {
                return NotFound(id);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            if(!await _mService.MediaExistsAsync(id))
            {
                return NotFound(id);
            }

            var media = await _mService.GetMediaByIdAsync(id);
            var result = await _mService.DeleteMediaAsync(media);

            if(result.IsSuccess)
            {
                return Ok();
            }

            return BadRequest(result.Exception.Message);
        }
    }
}