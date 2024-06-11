using Microsoft.AspNetCore.Http;

namespace TAB.Library.Backend.Infrastructure.Services.Abstractions
{
    public interface IBookFileService
    {
        Task<bool> CheckIfFileExist(int bookId);
        Task<bool> AddFile(int bookId, IFormFile file);
        Task<bool> DeleteFile(int bookId);
        Task<bool> UpdateFile(int bookId, IFormFile file);
    }
}
