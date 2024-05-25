using FluentValidation;
using MediatR;

namespace TAB.Library.Backend.Application.Commands
{
    public class CreateRentalCommand : IRequest<bool>
    {
        public int BookId { get; init; }
        public string Username { get; init; }

        public CreateRentalCommand(int bookId, string username)
        {
            BookId = bookId;
            Username = username;
        }
    }

    public class CreateRentalCommandValidator : AbstractValidator<CreateRentalCommand>
    {
        public CreateRentalCommandValidator()
        {
            RuleFor(x => x.Username)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Username is required");

            RuleFor(x => x.BookId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("BookId is required");
        }
    }
}
