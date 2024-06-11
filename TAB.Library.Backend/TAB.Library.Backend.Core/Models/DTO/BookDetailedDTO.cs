namespace TAB.Library.Backend.Core.Models.DTO
{
    public record BookDetailedDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int PublishYear { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? PdfContent { get; set; }
        public string ThumbnailSmallContent { get; set; } = string.Empty;
        public string ThumbnailMediumContent { get; set; } = string.Empty;
        public string ThumbnailLargeContent { get; set; } = string.Empty;
        public bool IsReserved { get; set; }
    }
}
