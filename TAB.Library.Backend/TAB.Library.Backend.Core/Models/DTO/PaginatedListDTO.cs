namespace TAB.Library.Backend.Core.Models.DTO
{
    public record PaginatedListDTO<T>
    {
        public List<T> List { get; set; } = new List<T>();
        public int TotalPages { get; set; }
    }
}
