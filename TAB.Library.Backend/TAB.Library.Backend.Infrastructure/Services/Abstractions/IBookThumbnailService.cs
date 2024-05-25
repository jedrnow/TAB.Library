using Microsoft.AspNetCore.Http;

namespace TAB.Library.Backend.Infrastructure.Services.Abstractions
{
    public interface IBookThumbnailService
    {
        Task<bool> CheckIfThumbnailsExist(int bookId);
        Task<bool> AddThumbnails(int bookId, IFormFile file);
        Task<bool> DeleteThumbnails(int bookId);
        Task<bool> UpdateThumbnails(int bookId, IFormFile file);
    }
}
