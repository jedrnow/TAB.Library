namespace TAB.Library.Backend.Core.Entities
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public virtual List<Book> Books { get; set; } = new List<Book>();
    }
}
