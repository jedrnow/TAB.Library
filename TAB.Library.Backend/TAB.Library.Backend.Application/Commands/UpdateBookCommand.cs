using FluentValidation;
using MediatR;
using TAB.Library.Backend.Application.Models;

namespace TAB.Library.Backend.Application.Commands
{
    public class UpdateBookCommand : IRequest<bool>
    {
        public int BookId { get; init; }
        public string Title { get; init; } = string.Empty;
        public int PublishYear { get; init; }
        public int AuthorId { get; init; }
        public int CategoryId { get; init; }
        public string Username { get; init; } = string.Empty;
        public string CategoryName { get; init; } = string.Empty;
        public string AuthorFirstName { get; init; } = string.Empty;
        public string AuthorLastName { get; init; } = string.Empty;

        public UpdateBookCommand(int bookId, UpdateBookInput input, string username)
        {
            BookId = bookId;
            Title = input.Title;
            PublishYear = input.PublishYear;
            AuthorId = input.AuthorId;
            CategoryId = input.CategoryId;
            Username = username;
            CategoryName = input.CategoryName;
            AuthorFirstName = input.AuthorFirstName;
            AuthorLastName = input.AuthorLastName;
        }
    }

    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.BookId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("BookId is required");

            RuleFor(x => x.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Title is required");

            RuleFor(x => x.PublishYear)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("PublishYear is required");

            RuleFor(x => x.AuthorId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("AuthorId cannot be negative");

            RuleFor(x => x.CategoryId)
                .Cascade(CascadeMode.Stop)
                .GreaterThanOrEqualTo(0).WithMessage("CategoryId cannot be negative");

            RuleFor(x => x.Username)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Username is required");

            When(x => x.CategoryId == 0, () =>
            {
                RuleFor(x => x.CategoryName)
                    .NotEmpty().WithMessage("CategoryName is required on adding new category");
            });

            When(x => x.AuthorId == 0, () =>
            {
                RuleFor(x => x.AuthorFirstName)
                    .NotEmpty().WithMessage("AuthorFirstName is required on adding new author");
                RuleFor(x => x.AuthorLastName)
                    .NotEmpty().WithMessage("AuthorLastName is required on adding new author");
            });
        }
    }
}
