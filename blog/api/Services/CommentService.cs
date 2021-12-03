using api.Data;
using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Services;

public class CommentService : ICommentService
{
    private readonly PostApiDbContext _ctx;

    public CommentService(PostApiDbContext context)
    {   
        _ctx = context;
    }

    public async Task<(bool IsSuccess, Exception Exception)> DeleteCommentAsync(Comment comment)
    {
        try
        {
            _ctx.Comments.Remove(comment);
            await _ctx.SaveChangesAsync();
            
            return (true, null);
        }
        catch(Exception e)
        {
            return (false, e);
        }
    }

    public Task<Comment> GetCommentById(Guid id)
        => _ctx.Comments.FirstOrDefaultAsync(c => c.Id == id);

    public Task<List<Comment>> GetCommentsByPostId(Guid postId)
        => _ctx.Comments
            .AsNoTracking()
            .Where(c => c.PostId == postId)
            .ToListAsync();

    public async Task<(bool IsSuccess, Exception Exception)> InsertCommentAsync(Comment comment)
    {
        try
        {
            await _ctx.Comments.AddAsync(comment);
            await _ctx.SaveChangesAsync();
            return (true, null);
        }
        catch(Exception e)
        {
            return (false, e);
        }
    }

    public async Task<(bool IsSuccess, Exception Exception)> UpdateCommentAsync(Comment comment)
    {
        try
        {
            _ctx.Comments.Update(comment);
            await _ctx.SaveChangesAsync();
            return (true, null);
        }
        catch(Exception e)
        {
            return (false, e);
        }
    }
}