using System.Security.Claims;

namespace TAB.Library.Backend.Infrastructure.Services.Abstractions
{
    public interface IUserService
    {
        Task<bool> UsernameExistsInDb(string username);
        Task<bool> EmailExistsInDb(string email);
        Task<bool> RegisterUser(string username, string password, string email, string firstname, string lastname, string phoneNumber);
        Task<bool> Login(string username, string password);
        Task<ClaimsIdentity> GetClaimsIdentity(string username);
        Task<int> GetUserIdByName(string username);
    }
}
