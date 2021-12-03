using api.Entities;

namespace api.Services;

public interface IMediaService
{
    Task<(bool IsSuccess, Exception Exception)> InsertMediaAsync(Media media);
    Task<Media> GetMediaByIdAsync(Guid id);
    Task<(bool IsSuccess, Exception Exception)> DeleteMediaAsync(Media media);
    Task<bool> MediaExistsAsync(Guid id);
}