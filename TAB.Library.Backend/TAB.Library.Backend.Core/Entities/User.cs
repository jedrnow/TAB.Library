namespace TAB.Library.Backend.Core.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public virtual List<Rental> UsersRentals { get; set; } = new List<Rental>();
    }
}
