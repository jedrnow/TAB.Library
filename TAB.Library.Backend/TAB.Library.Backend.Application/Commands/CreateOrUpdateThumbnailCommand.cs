using FluentValidation;
using MediatR;

namespace TAB.Library.Backend.Application.Commands
{
    public class CreateOrUpdateThumbnailCommand : IRequest<bool>
    {
        public int BookId { get; init; }
        public IFormFile File { get; init; }
        public string Username { get; init; }

        public CreateOrUpdateThumbnailCommand(int bookId, IFormFile file, string username)
        {
            BookId = bookId;
            File = file;
            Username = username;
        }
    }

    public class CreateOrUpdateThumbnailCommandValidator : AbstractValidator<CreateOrUpdateThumbnailCommand>
    {
        public CreateOrUpdateThumbnailCommandValidator()
        {
            RuleFor(x => x.BookId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("BookId is required");

            RuleFor(x => x.File)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("File is required");
        }
    }
}
