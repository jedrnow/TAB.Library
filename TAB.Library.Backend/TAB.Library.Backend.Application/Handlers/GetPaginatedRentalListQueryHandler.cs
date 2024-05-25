using MediatR;
using TAB.Library.Backend.Application.Queries;
using TAB.Library.Backend.Core.Models.DTO;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;

namespace TAB.Library.Backend.Application.Handlers
{
    public class GetPaginatedRentalListQueryHandler : IRequestHandler<GetPaginatedRentalListQuery, PaginatedListDTO<RentalDTO>>
    {
        private readonly IRentalService _rentalService;
        private readonly IUserService _userService;

        public GetPaginatedRentalListQueryHandler(IRentalService rentalService, IUserService userService)
        {
            _rentalService = rentalService;
            _userService = userService;
        }

        public async Task<PaginatedListDTO<RentalDTO>> Handle(GetPaginatedRentalListQuery request, CancellationToken cancellationToken)
        {
            int userId = await _userService.GetUserIdByName(request.Username);

            PaginatedListDTO<RentalDTO> result = await _rentalService.GetUsersRentalsPaginatedList(userId, request.PageNumber, request.PageSize);

            return result;
        }
    }
}
