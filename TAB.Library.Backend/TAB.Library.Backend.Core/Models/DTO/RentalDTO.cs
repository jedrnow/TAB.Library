namespace TAB.Library.Backend.Core.Models.DTO
{
    public record RentalDTO
    {
        public int Id { get; set; }
        public DateTime FromUtc { get; set; }
        public DateTime ToUtc { get; set; }
        public bool IsReturned { get; set; } = false;
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public int UserId { get; set; }
        public string RentedBy { get; set; }
    }
}
