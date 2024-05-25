using MediatR;
using TAB.Library.Backend.Application.Commands;
using TAB.Library.Backend.Core.Entities;
using TAB.Library.Backend.Core.Exceptions;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;

namespace TAB.Library.Backend.Application.Handlers
{
    public class CreateOrUpdateThumbnailCommandHandler : IRequestHandler<CreateOrUpdateThumbnailCommand, bool>
    {
        private readonly IUserService _userService;
        private readonly IBookService _bookService;
        private readonly IBookThumbnailService _bookThumbnailService;

        public CreateOrUpdateThumbnailCommandHandler(IUserService userService, IBookService bookService, IBookThumbnailService bookThumbnailService)
        {
            _userService = userService;
            _bookService = bookService;
            _bookThumbnailService = bookThumbnailService;
        }

        public async Task<bool> Handle(CreateOrUpdateThumbnailCommand request, CancellationToken cancellationToken)
        {
            bool userHasAdminPermissions = await _userService.CheckAdminPermissions(request.Username);
            if (!userHasAdminPermissions) throw new UserUnauthorizedException();

            bool bookExists = await _bookService.CheckIfBookExists(request.BookId);
            if (!bookExists) throw new EntityNotFoundException(typeof(Book), request.BookId);

            bool thumbnailsExist = await _bookThumbnailService.CheckIfThumbnailsExist(request.BookId);

            bool result = thumbnailsExist ? await _bookThumbnailService.UpdateThumbnails(request.BookId, request.File) : await _bookThumbnailService.AddThumbnails(request.BookId, request.File);

            return result;
        }
    }
}
