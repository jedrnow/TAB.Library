using MediatR;
using TAB.Library.Backend.Application.Queries;
using TAB.Library.Backend.Core.Models.DTO;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;
using TAB.Library.Backend.Core.Exceptions;

namespace TAB.Library.Backend.Application.Handlers
{
    public class GetPaginatedUserListQueryHandler : IRequestHandler<GetPaginatedUserListQuery, PaginatedListDTO<UserDTO>>
    {
        private readonly IUserService _userService;

        public GetPaginatedUserListQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<PaginatedListDTO<UserDTO>> Handle(GetPaginatedUserListQuery request, CancellationToken cancellationToken)
        {
            bool userHasAdminPermissions = await _userService.CheckAdminPermissions(request.Username);
            if (!userHasAdminPermissions) throw new UserUnauthorizedException();

            PaginatedListDTO<UserDTO> result = await _userService.GetPaginatedUserList(request.PageNumber, request.PageSize);

            return result;
        }
    }
}
