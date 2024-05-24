using MediatR;
using TAB.Library.Backend.Application.Queries;
using TAB.Library.Backend.Core.Models.DTO;
using TAB.Library.Backend.Core.Models;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;

namespace TAB.Library.Backend.Application.Handlers
{
    public class GetPaginatedBookListQueryHandler : IRequestHandler<GetPaginatedBookListQuery, PaginatedListDTO<BookDTO>>
    {
        private readonly IBookService _bookService;

        public GetPaginatedBookListQueryHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<PaginatedListDTO<BookDTO>> Handle(GetPaginatedBookListQuery request, CancellationToken cancellationToken)
        {
            PaginatedListDTO<BookDTO> result = await _bookService.GetPaginatedBookList(request.PageNumber, request.PageSize);

            return result;
        }
    }
}
