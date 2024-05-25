using TAB.Library.Backend.Core.Constants;

namespace TAB.Library.Backend.Core.Entities
{
    public class BookThumbnail : BaseEntity
    {
        public ThumbnailSize Size { get; set; }
        public string Content { get; set; } = string.Empty;
        public Book Book { get; set; }
        public int? BookId { get; set; }
    }
}
