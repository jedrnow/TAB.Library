namespace TAB.Library.Backend.Core.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public int PublishYear { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public int? BookFileId { get; set; } = null;
        public BookFile? BookFile { get; set; } = null;
        public virtual List<Rental> RentalHistory { get; set; } = new List<Rental>();
    }
}
