namespace TAB.Library.Backend.Core.Entities
{
    public class BookFile : BaseEntity
    {
        public string FileName { get; set; } = string.Empty;
        public byte[] ByteContent { get; set; } = [];
        public Book Book { get; set; }
        public int? BookId { get; set; }
    }
}
