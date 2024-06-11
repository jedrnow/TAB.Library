using TAB.Library.Backend.Core.Models.DTO;

namespace TAB.Library.Backend.Infrastructure.Services.Abstractions
{
    public interface IBookService
    {
        Task<bool> CheckIfBookExists(int bookId);
        Task<int> CreateBook(string title, int publishYear, int authorId, int categoryId);
        Task<bool> UpdateBook(int bookId, string title, int publishYear, int authorId, int categoryId);
        Task<bool> DeleteBook(int bookId);
        Task<BookDetailedDTO> GetBookById(int bookId);
        Task<PaginatedListDTO<BookDTO>> GetPaginatedBookList(int pageNumber, int pageSize);
    }
}
