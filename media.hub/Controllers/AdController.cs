using System.Drawing;
using System.Diagnostics.Contracts;
using media.hub.data;
using media.hub.entities;
using media.hub.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

namespace media.hub.controllers;

[ApiController]
[Route("api/[controller]")]
public  class AdController: ControllerBase
{
    private readonly MediaContext _ctx;

    public AdController(MediaContext ctx)
    {
        _ctx = ctx;
    }

    [HttpPost]
    public async Task<IActionResult> PostAd([FromForm]AdModel ad)
    {
        var mFiles = ad.Files.Select(GetImageEntity).ToList();

        var adEntity = new Ad()
        {
            Id = Guid.NewGuid(),
            Title = ad.Title,
            Description = ad.Description,
            Tags = string.Join(',', ad.Tags),
            Medias = mFiles
        };

        await _ctx.Ads.AddAsync(adEntity);
        await _ctx.SaveChangesAsync();

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAds()
    {
        var ads = await _ctx.Ads
            .AsNoTracking()
            .Include(ad => ad.Medias)
            .Select(ad => new 
            {
                Id = ad.Id,
                Title = ad.Title,
                Description = ad.Description,
                Tags = ad.Tags.Split(',', StringSplitOptions.RemoveEmptyEntries),
                Files = ad.Medias.Select(m => new 
                    {
                        Id = m.Id,
                        ContentType = m.ContentType,
                        SizeInMb = m.SizeInMb
                    })
            }).ToListAsync();

        return Ok(ads);
    }

    [HttpGet]
    [Route("/media/{id}")]
    public async Task<IActionResult> GetMedia(Guid id)
    {
        var file = await _ctx.Medias.FirstOrDefaultAsync(m => m.Id == id);

        var stream = new MemoryStream(file.Data);

        return File(stream, file.ContentType);
    }

    private List<(Guid Id, string ContentType, double Size)> GetFiles(Ad ad)
        => ad.Medias.Select(m => (m.Id, m.ContentType, m.SizeInMb)).ToList();

    private Media GetImageEntity(IFormFile file)
    {
        using var stream = new MemoryStream();

        file.CopyTo(stream);

        return new Media()
        {
            Id = Guid.NewGuid(),
            ContentType = file.ContentType,
            Data = stream.ToArray()
        };
    }
}