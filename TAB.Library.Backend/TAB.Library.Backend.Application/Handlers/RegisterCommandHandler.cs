using MediatR;
using TAB.Library.Backend.Application.Commands;
using TAB.Library.Backend.Core.Entities;
using TAB.Library.Backend.Core.Exceptions;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;

namespace TAB.Library.Backend.Application.Handlers
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, bool>
    {
        private readonly IUserService _userService;
        public RegisterCommandHandler(IUserService userSerice)
        {
            _userService = userSerice;
        }

        public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await ValidateInput(request.Username, request.Email);

            bool result = await _userService.RegisterUser(request.Username, request.Password, request.Email, request.FirstName, request.LastName, request.PhoneNumber);

            return result;
        }

        public async Task ValidateInput(string username, string email)
        {
            bool usernameCheck = await _userService.UsernameExistsInDb(username);
            if (usernameCheck) throw new EntityAlreadyExistsException(typeof(User));

            bool emailCheck = await _userService.EmailExistsInDb(email);
            if (emailCheck) throw new EntityAlreadyExistsException(typeof(User));
        }
    }
}
