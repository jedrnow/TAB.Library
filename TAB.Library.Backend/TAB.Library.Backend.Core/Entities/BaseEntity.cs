namespace TAB.Library.Backend.Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAtUtc { get; set; } = DateTime.UtcNow;

        public void Update()
        {
            UpdatedAtUtc = DateTime.UtcNow;
        }
    }
}
