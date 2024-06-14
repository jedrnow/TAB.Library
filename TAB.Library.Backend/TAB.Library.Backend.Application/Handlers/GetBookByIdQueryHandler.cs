using MediatR;
using TAB.Library.Backend.Application.Queries;
using TAB.Library.Backend.Core.Models.DTO;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;

namespace TAB.Library.Backend.Application.Handlers
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDetailedDTO>
    {
        private readonly IBookService _bookService;
        private readonly IUserService _userService;

        public GetBookByIdQueryHandler(IBookService bookService, IUserService userService)
        {
            _bookService = bookService;
            _userService = userService;
        }

        public async Task<BookDetailedDTO> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            int currentUserId = await _userService.GetUserIdByName(request.Username);

            BookDetailedDTO result = await _bookService.GetBookById(request.BookId, currentUserId);

            return result;
        }
    }
}
