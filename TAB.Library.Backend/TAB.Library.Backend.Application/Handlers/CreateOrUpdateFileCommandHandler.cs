using MediatR;
using TAB.Library.Backend.Application.Commands;
using TAB.Library.Backend.Core.Entities;
using TAB.Library.Backend.Core.Exceptions;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;

namespace TAB.Library.Backend.Application.Handlers
{
    public class CreateOrUpdateFileCommandHandler : IRequestHandler<CreateOrUpdateFileCommand, bool>
    {
        private readonly IUserService _userService;
        private readonly IBookService _bookService;
        private readonly IBookFileService _bookFileService;

        public CreateOrUpdateFileCommandHandler(IUserService userService, IBookService bookService, IBookFileService bookFileService)
        {
            _userService = userService;
            _bookService = bookService;
            _bookFileService = bookFileService;
        }

        public async Task<bool> Handle(CreateOrUpdateFileCommand request, CancellationToken cancellationToken)
        {
            bool userHasAdminPermissions = await _userService.CheckAdminPermissions(request.Username);
            if (!userHasAdminPermissions) throw new UserUnauthorizedException();

            bool bookExists = await _bookService.CheckIfBookExists(request.BookId);
            if (!bookExists) throw new EntityNotFoundException(typeof(Book), request.BookId);

            bool fileExist = await _bookFileService.CheckIfFileExist(request.BookId);

            bool result = fileExist ? await _bookFileService.UpdateFile(request.BookId, request.File) : await _bookFileService.AddFile(request.BookId, request.File);

            return result;
        }
    }
}
