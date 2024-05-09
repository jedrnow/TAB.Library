using TAB.Library.Backend.Core.Constants;
using TAB.Library.Backend.Core.Models.DTO;
using TAB.Library.Backend.Core.Models;

namespace TAB.Library.Backend.Infrastructure.Services.Abstractions
{
    public interface IRentalService
    {
        Task<bool> AddRental(int bookId, int userId, int? rentalPeriodInDays = null);
        Task<bool> ExtendRental(int rentalId, int daysToAdd);
        Task<bool> FinishRental(int rentalId);
        Task<PaginatedList<RentalDTO>> GetUsersRentalsPaginatedList(int userId, int pageNumber, int pageSize = DefaultSettings.PageSize, bool onlyActiveRentals = false);
        Task<PaginatedList<RentalDTO>> GetRentalsPaginatedList(int pageNumber, int pageSize = DefaultSettings.PageSize, bool onlyActiveRentals = false);
    }
}
