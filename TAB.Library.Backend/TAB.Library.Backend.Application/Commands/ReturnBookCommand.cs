using FluentValidation;
using MediatR;

namespace TAB.Library.Backend.Application.Commands
{
    public class ReturnBookCommand : IRequest<bool>
    {
        public int RentalId { get; init; }
        public string Username { get; init; }
        public ReturnBookCommand(int rentalId, string username)
        {
            RentalId = rentalId;
            Username = username;
        }
    }

    public class ReturnBookCommandValidator : AbstractValidator<ReturnBookCommand>
    {
        public ReturnBookCommandValidator()
        {
            RuleFor(x => x.RentalId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("RentalId is required");

            RuleFor(x => x.Username)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Username is required");
        }
    }
}
