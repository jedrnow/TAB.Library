using MediatR;
using TAB.Library.Backend.Application.Commands;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;

namespace TAB.Library.Backend.Application.Handlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, bool>
    {
        private readonly IUserService _userService;

        public LoginCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            bool result = await _userService.Login(request.Username, request.Password);

            return result;
        }
    }
}
