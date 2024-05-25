using MediatR;
using TAB.Library.Backend.Application.Commands;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;

namespace TAB.Library.Backend.Application.Handlers
{
    public class ReturnBookCommandHandler : IRequestHandler<ReturnBookCommand, bool>
    {
        private readonly IUserService _userService;
        private readonly IRentalService _rentalService;

        public ReturnBookCommandHandler(IUserService userService, IRentalService rentalService)
        {
            _userService = userService;
            _rentalService = rentalService;
        }

        public async Task<bool> Handle(ReturnBookCommand request, CancellationToken cancellationToken)
        {
            int userId = await _userService.GetUserIdByName(request.Username);

            bool result = await _rentalService.FinishRental(request.RentalId, userId);

            return result;
        }
    }
}
