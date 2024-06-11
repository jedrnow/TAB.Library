using MediatR;
using TAB.Library.Backend.Application.Commands;
using TAB.Library.Backend.Core.Exceptions;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;

namespace TAB.Library.Backend.Application.Handlers
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
    {
        private readonly IUserService _userService;
        private readonly IBookService _bookService;

        public DeleteBookCommandHandler(IUserService userService, IBookService bookService)
        {
            _userService = userService;
            _bookService = bookService;
        }

        public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            bool userHasAdminPermissions = await _userService.CheckAdminPermissions(request.Username);
            if (!userHasAdminPermissions) throw new UserUnauthorizedException();

            bool bookDeleted = await _bookService.DeleteBook(request.BookId);

            return bookDeleted;
        }
    }
}
