using api.Data;
using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Services;

public class MediaService : IMediaService
{
    private readonly PostApiDbContext _ctx;

    public MediaService(PostApiDbContext context)
    {   
        _ctx = context;
    }

    public async Task<(bool IsSuccess, Exception Exception)> DeleteMediaAsync(Media media)
    {
        try
        {
            _ctx.Medias.Remove(media);
            await _ctx.SaveChangesAsync();
            return (true, null);
        }
        catch(Exception e)
        {
            return (false, e);
        }
    }

    public Task<Media> GetMediaByIdAsync(Guid id)
        => _ctx.Medias.FirstOrDefaultAsync(m => m.Id == id);

    public async Task<(bool IsSuccess, Exception Exception)> InsertMediaAsync(Media media)
    {
        try
        {
            await _ctx.Medias.AddAsync(media);
            await _ctx.SaveChangesAsync();
            return (true, null);
        }
        catch(Exception e)
        {
            return (false, e);
        }
    }

    public Task<bool> MediaExistsAsync(Guid id)
        => _ctx.Medias.AnyAsync(m => m.Id == id);
}