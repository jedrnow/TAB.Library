namespace TAB.Library.Backend.Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public virtual List<Book> Books { get; set; } = new List<Book>();
    }
}
