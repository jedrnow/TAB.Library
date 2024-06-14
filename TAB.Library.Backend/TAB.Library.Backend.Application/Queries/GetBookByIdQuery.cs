using FluentValidation;
using MediatR;
using TAB.Library.Backend.Core.Models.DTO;

namespace TAB.Library.Backend.Application.Queries
{
    public class GetBookByIdQuery : IRequest<BookDetailedDTO>
    {
        public int BookId { get; init; }
        public string Username { get; init; }

        public GetBookByIdQuery(int bookId, string username)
        {
            BookId = bookId;
            Username = username;
        }
    }

    public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdQueryValidator()
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
