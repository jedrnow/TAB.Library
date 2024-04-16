using FluentValidation;
using MediatR;
using TAB.Library.Backend.Application.Models;
using TAB.Library.Backend.Core.Constants;

namespace TAB.Library.Backend.Application.Commands
{
    public class LoginCommand : IRequest<bool>
    {
        public string Username { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
        public LoginCommand(LoginInput input)
        {
            Username = input.Username;
            Password = input.Password;
        }
    }

    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Username)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Username is required.")
                .Length(DefaultSettings.MinUsernameLength, DefaultSettings.MaxUsernameLength).WithMessage($"Username length must be between {DefaultSettings.MinUsernameLength} and {DefaultSettings.MaxUsernameLength}");

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Password is required.")
                .Length(DefaultSettings.MinPasswordLength, DefaultSettings.MaxPasswordLength).WithMessage($"Password length must be between {DefaultSettings.MinPasswordLength} and {DefaultSettings.MaxPasswordLength}");
        }
    }
}
