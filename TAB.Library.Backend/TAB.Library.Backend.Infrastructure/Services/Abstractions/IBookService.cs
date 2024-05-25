using TAB.Library.Backend.Core.Models.DTO;

namespace TAB.Library.Backend.Infrastructure.Services.Abstractions
{
    public interface IBookService
    {
        Task<bool> CheckIfBookExists(int bookId);
        Task<BookDTO> GetBookById(int bookId);
        Task<PaginatedListDTO<BookDTO>> GetPaginatedBookList(int pageNumber, int pageSize);
    }
}
