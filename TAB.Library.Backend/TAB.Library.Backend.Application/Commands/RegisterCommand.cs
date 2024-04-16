using FluentValidation;
using MediatR;
using TAB.Library.Backend.Application.Models;
using TAB.Library.Backend.Core.Constants;

namespace TAB.Library.Backend.Application.Commands
{
    public class RegisterCommand : IRequest<bool>
    {
        public string Username { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
        public string ConfirmPassword { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string FirstName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
        public string PhoneNumber { get; init; } = string.Empty;

        public RegisterCommand(RegisterInput input)
        {
            Username = input.Username;
            Password = input.Password;
            ConfirmPassword = input.ConfirmPassword;
            Email = input.Email;
            FirstName = input.FirstName;
            LastName = input.LastName;
            PhoneNumber = input.PhoneNumber;
        }
    }

    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.Username)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Username is required.")
                .Length(DefaultSettings.MinUsernameLength, DefaultSettings.MaxUsernameLength).WithMessage($"Username length must be between {DefaultSettings.MinUsernameLength} and {DefaultSettings.MaxUsernameLength}")
                .Must(x => !x.Contains(" ")).WithMessage("Username cannot contain whitespace.");

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Password is required.")
                .Length(DefaultSettings.MinPasswordLength, DefaultSettings.MaxPasswordLength).WithMessage($"Password length must be between {DefaultSettings.MinPasswordLength} and {DefaultSettings.MaxPasswordLength}")
                .Must(x => !x.Contains(" ")).WithMessage("Password cannot contain whitespace.");

            RuleFor(x => x.ConfirmPassword)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Please confirm your password.")
                .Equal(x => x.Password).WithMessage($"Password does not match.");

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Email is required.")
                .Length(DefaultSettings.MinEmailLength, DefaultSettings.MaxEmailLength).WithMessage($"Email length must be between {DefaultSettings.MinEmailLength} and {DefaultSettings.MaxEmailLength}")
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).WithMessage("Email must contain '@' sign.")
                .Must(x => !x.Contains(" ")).WithMessage("Email cannot contain whitespace.");

            RuleFor(x => x.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Firstname is required.")
                .Must(x => !x.Contains(" ")).WithMessage("Firstname cannot contain whitespace.");

            RuleFor(x => x.LastName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Lastname is required.")
                .Must(x => !x.Contains(" ")).WithMessage("Lastname cannot contain whitespace.");

            RuleFor(x => x.PhoneNumber)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Phone number is required.")
                .Length(DefaultSettings.MinPhoneNumberLength, DefaultSettings.MaxPhoneNumberLength).WithMessage($"PhoneNumber length must be between {DefaultSettings.MinPhoneNumberLength} and {DefaultSettings.MaxPhoneNumberLength}")
                .Matches(@"^\d+$").WithMessage("Phone number must only contain numbers.")
                .Must(x => !x.Contains(" ")).WithMessage("Phone number cannot contain whitespace.");

        }
    }
}
