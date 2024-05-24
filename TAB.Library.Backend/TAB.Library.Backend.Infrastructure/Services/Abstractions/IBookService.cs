using TAB.Library.Backend.Core.Models.DTO;
using TAB.Library.Backend.Core.Models;

namespace TAB.Library.Backend.Infrastructure.Services.Abstractions
{
    public interface IBookService
    {
        Task<PaginatedListDTO<BookDTO>> GetPaginatedBookList(int pageNumber, int pageSize);
    }
}
