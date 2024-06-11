using FluentValidation;
using MediatR;

namespace TAB.Library.Backend.Application.Commands
{
    public class DeleteBookCommand : IRequest<bool>
    {
        public int BookId { get; init; }
        public string Username { get; init; } = string.Empty;

        public DeleteBookCommand(int bookId, string username)
        {
            BookId = bookId;
            Username = username;
        }
    }

    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(x => x.BookId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("BookId is required");

            RuleFor(x => x.Username)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Username is required");
        }
    }
}
