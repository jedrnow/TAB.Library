using System.Security.Claims;
using TAB.Library.Backend.Core.Models.DTO;

namespace TAB.Library.Backend.Infrastructure.Services.Abstractions
{
    public interface IUserService
    {
        Task<bool> CheckAdminPermissions(string username);
        Task<bool> UsernameExistsInDb(string username);
        Task<bool> EmailExistsInDb(string email);
        Task<bool> RegisterUser(string username, string password, string email, string firstname, string lastname, string phoneNumber);
        Task<bool> Login(string username, string password);
        Task<ClaimsIdentity> GetClaimsIdentity(string username);
        Task<int> GetUserIdByName(string username);
        Task<PaginatedListDTO<UserDTO>> GetPaginatedUserList(int pageNumber, int pageSize);
    }
}
