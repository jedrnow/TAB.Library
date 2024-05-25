using MediatR;
using TAB.Library.Backend.Application.Commands;
using TAB.Library.Backend.Core.Entities;
using TAB.Library.Backend.Core.Exceptions;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;

namespace TAB.Library.Backend.Application.Handlers
{
    public class CreateRentalCommandHandler : IRequestHandler<CreateRentalCommand, bool>
    {
        private readonly IUserService _userService;
        private readonly IBookService _bookService;
        private readonly IRentalService _rentalService;

        public CreateRentalCommandHandler(IUserService userService, IBookService bookService, IRentalService rentalService)
        {
            _userService = userService;
            _bookService = bookService;
            _rentalService = rentalService;
        }

        public async Task<bool> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
        {
            bool bookExists = await _bookService.CheckIfBookExists(request.BookId);
            if (!bookExists) throw new EntityNotFoundException(typeof(Book), request.BookId);

            int userId = await _userService.GetUserIdByName(request.Username);

            bool result = await _rentalService.AddRental(request.BookId, userId);

            return result;
        }
    }
}
