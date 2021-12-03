using api.Entities;

namespace api.Services;

public interface IPostService
{
    Task<(bool IsSuccess, Exception Exception)> InsertPostAsync(Post post);
    Task<List<Post>> GetPostsAsync(int take, int skip);
    Task<Post> GetPostByIdAsync(Guid id);
    Task<(bool IsSuccess, Exception Exception)> UpdatePostAsync(Post post);
    Task<bool> PostExistsAsync(Guid id);
    Task<(bool IsSuccess, Exception Exception)> DeletePostAsync(Post post);
}