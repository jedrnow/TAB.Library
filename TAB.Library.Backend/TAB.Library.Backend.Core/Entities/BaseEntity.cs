namespace TAB.Library.Backend.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
    }
}
