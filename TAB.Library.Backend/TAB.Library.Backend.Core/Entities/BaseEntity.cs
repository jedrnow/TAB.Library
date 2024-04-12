namespace TAB.Library.Backend.Core.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; private set; }
        public DateTime CreatedAtUtc { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAtUtc { get; private set; } = DateTime.UtcNow;

        public void Update()
        {
            UpdatedAtUtc = DateTime.UtcNow;
        }
    }
}
