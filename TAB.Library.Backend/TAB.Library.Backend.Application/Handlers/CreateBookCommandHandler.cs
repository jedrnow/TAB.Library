using MediatR;
using TAB.Library.Backend.Application.Commands;
using TAB.Library.Backend.Core.Exceptions;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;

namespace TAB.Library.Backend.Application.Handlers
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IUserService _userService;
        private readonly IBookService _bookService;

        public CreateBookCommandHandler(IUserService userService, IBookService bookService)
        {
            _userService = userService;
            _bookService = bookService;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            bool userHasAdminPermissions = await _userService.CheckAdminPermissions(request.Username);
            if (!userHasAdminPermissions) throw new UserUnauthorizedException();

            int createdBookId = await _bookService.CreateBook(request.Title, request.PublishYear, request.AuthorId, request.CategoryId);

            return createdBookId;
        }
    }
}
