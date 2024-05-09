namespace TAB.Library.Backend.Core.Entities
{
    public class Rental : BaseEntity
    {
        public DateTime FromUtc { get; set; } = DateTime.UtcNow;
        public DateTime ToUtc { get; set; }
        public bool IsReturned { get; set; } = false;
        public Book Book { get; set; }
        public int BookId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
