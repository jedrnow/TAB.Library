using MediatR;
using TAB.Library.Backend.Application.Commands;
using TAB.Library.Backend.Core.Exceptions;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;

namespace TAB.Library.Backend.Application.Handlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, bool>
    {
        private readonly IUserService _userService;
        private readonly IBookService _bookService;

        public UpdateBookCommandHandler(IUserService userService, IBookService bookService)
        {
            _userService = userService;
            _bookService = bookService;
        }

        public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            bool userHasAdminPermissions = await _userService.CheckAdminPermissions(request.Username);
            if (!userHasAdminPermissions) throw new UserUnauthorizedException();

            bool bookUpdated = await _bookService.UpdateBook(request.BookId, request.Title, request.PublishYear, request.AuthorId, request.CategoryId, request.CategoryName, request.AuthorFirstName, request.AuthorLastName);

            return bookUpdated;
        }
    }
}
