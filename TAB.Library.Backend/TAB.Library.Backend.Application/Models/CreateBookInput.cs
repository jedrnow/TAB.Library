namespace TAB.Library.Backend.Application.Models
{
    public record CreateBookInput
    {
        public string Title { get; init; } = string.Empty;
        public int PublishYear { get; init; }
        public int AuthorId { get; init; }
        public int CategoryId { get; init; }
        public string CategoryName { get; init; } = string.Empty;
        public string AuthorFirstName { get; init; } = string.Empty;
        public string AuthorLastName { get; init; } = string.Empty;
    }
}
