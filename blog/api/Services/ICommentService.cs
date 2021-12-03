using api.Entities;

namespace api.Services;

public interface ICommentService
{
    Task<(bool IsSuccess, Exception Exception)> InsertCommentAsync(Comment comment);
    Task<(bool IsSuccess, Exception Exception)> UpdateCommentAsync(Comment comment);
    Task<(bool IsSuccess, Exception Exception)> DeleteCommentAsync(Comment comment);
    Task<List<Comment>> GetCommentsByPostId(Guid postId);
    Task<Comment> GetCommentById(Guid id);
}