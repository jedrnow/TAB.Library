using TAB.Library.Backend.Core.Constants;
using TAB.Library.Backend.Core.Models.DTO;

namespace TAB.Library.Backend.Infrastructure.Services.Abstractions
{
    public interface IRentalService
    {
        Task<bool> AddRental(int bookId, int userId, int? rentalPeriodInDays = null);
        Task<bool> ExtendRental(int rentalId, int daysToAdd, int userId);
        Task<bool> FinishRental(int rentalId, int userId);
        Task<PaginatedListDTO<RentalDTO>> GetUsersRentalsPaginatedList(int userId, int pageNumber, int pageSize = DefaultSettings.PageSize, bool onlyActiveRentals = false);
        Task<PaginatedListDTO<RentalDTO>> GetRentalsPaginatedList(int pageNumber, int pageSize = DefaultSettings.PageSize, bool onlyActiveRentals = false);
    }
}
