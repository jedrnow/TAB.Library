using FluentValidation;
using MediatR;
using TAB.Library.Backend.Application.Models;

namespace TAB.Library.Backend.Application.Commands
{
    public class CreateBookCommand : IRequest<int>
    {
        public string Title { get; init; } = string.Empty;
        public int PublishYear { get; init; }
        public int AuthorId { get; init; }
        public int CategoryId { get; init; }
        public string Username { get; init; } = string.Empty;

        public CreateBookCommand(CreateBookInput input, string username)
        {
            Title = input.Title;
            PublishYear = input.PublishYear;
            AuthorId = input.AuthorId;
            CategoryId = input.CategoryId;
            Username = username;
        }
    }

    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Title is required");

            RuleFor(x => x.PublishYear)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("PublishYear is required");

            RuleFor(x => x.AuthorId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("AuthorId is required");

            RuleFor(x => x.CategoryId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("CategoryId is required");

            RuleFor(x => x.Username)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Username is required");
        }
    }
}
