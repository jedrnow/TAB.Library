using Microsoft.AspNetCore.Http;

namespace TAB.Library.Backend.Infrastructure.Services.Abstractions
{
    public interface IBookThumbnailService
    {
        Task<bool> AddThumbnails(int bookId, IFormFile file);
    }
}
