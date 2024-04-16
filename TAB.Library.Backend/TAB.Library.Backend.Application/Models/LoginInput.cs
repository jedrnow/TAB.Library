namespace TAB.Library.Backend.Application.Models
{
    public record LoginInput
    {
        public string Username { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
    }
}
