using api.Data;
using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Services;

public class PostService : IPostService
{
    private readonly PostApiDbContext _ctx;

    public PostService(PostApiDbContext context)
    {   
        _ctx = context;
    }

    public async Task<(bool IsSuccess, Exception Exception)> DeletePostAsync(Post post)
    {
        try
        {
            _ctx.Posts.Remove(post);
            await _ctx.SaveChangesAsync();
            return (true, null);
        }
        catch(Exception e)
        {
            return (false, e);
        }
    }

    public Task<Post> GetPostByIdAsync(Guid id)
        => _ctx.Posts
            .AsNoTracking()
            .Where(p => p.Id == id)
            .Include(p => p.Comments)
            .FirstOrDefaultAsync();

    public Task<List<Post>> GetPostsAsync(int take = 10, int skip = 0)
        => _ctx.Posts
            .AsNoTracking()
            .Skip(skip)
            .Take(take)
            .Include(p => p.Comments)
            .ToListAsync();

    public async Task<(bool IsSuccess, Exception Exception)> InsertPostAsync(Post post)
    {
        try
        {
            await _ctx.Posts.AddAsync(post);
            await _ctx.SaveChangesAsync();
            return (true, null);
        }
        catch(Exception e)
        {
            return (false, e);
        }
    }

    public Task<bool> PostExistsAsync(Guid id)
        => _ctx.Posts.AnyAsync(p => p.Id == id);

    public async Task<(bool IsSuccess, Exception Exception)> UpdatePostAsync(Post post)
    {
        try
        {
            _ctx.Posts.Update(post);
            await _ctx.SaveChangesAsync();
            return (true, null);
        }
        catch(Exception e)
        {
            return (false, e);
        }
    }
}