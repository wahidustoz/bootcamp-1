using movies.Entities;

namespace movies.Services;

public interface IGenreService
{
    Task<(bool IsSuccess, Exception Exception)> CreateAsync(Genre genre);
    Task<List<Genre>> GetAllAsync();
    Task<Genre> GetAsync(Guid id);
    Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid id);
    Task<bool> ExistsAsync(Guid id);
}