using AutoMapper;
using TAB.Library.Backend.Core.Constants;
using TAB.Library.Backend.Core.Entities;
using TAB.Library.Backend.Core.Exceptions;
using TAB.Library.Backend.Core.Models;
using TAB.Library.Backend.Core.Models.DTO;
using TAB.Library.Backend.Infrastructure.Repositories.Abstractions;
using TAB.Library.Backend.Infrastructure.Services.Abstractions;

namespace TAB.Library.Backend.Infrastructure.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;
        public RentalService(IRentalRepository rentalRepository, IMapper mapper)
        {
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddRental(int bookId, int userId, int? rentalPeriodInDays = null)
        {
            bool bookNotAvailable = (await _rentalRepository.GetListAsync(x => x.BookId == bookId && !x.IsReturned)).Count > 0;
            if (bookNotAvailable) throw new RentalNotAvailableException();

            Rental newRental = new()
            {
                BookId = bookId,
                UserId = userId,
                FromUtc = DateTime.UtcNow,
                ToUtc = DateTime.UtcNow.AddDays(rentalPeriodInDays ?? DefaultSettings.RentalPeriodInDays)
            };

            await _rentalRepository.AddAsync(newRental);

            return await _rentalRepository.SaveChangesAsync();
        }

        public async Task<bool> ExtendRental(int rentalId, int daysToAdd)
        {
            Rental? rental = await _rentalRepository.GetAsync(rentalId);
            if (rental == null)
            {
                throw new EntityNotFoundException(typeof(Rental), rentalId);
            }

            rental.ToUtc = rental.ToUtc.AddDays(daysToAdd);

            return await _rentalRepository.SaveChangesAsync();
        }

        public async Task<bool> FinishRental(int rentalId)
        {
            Rental? rental = await _rentalRepository.GetAsync(rentalId);
            if (rental == null)
            {
                throw new EntityNotFoundException(typeof(Rental), rentalId);
            }

            rental.IsReturned = true;

            return await _rentalRepository.SaveChangesAsync();
        }

        public async Task<PaginatedListDTO<RentalDTO>> GetUsersRentalsPaginatedList(int userId, int pageNumber, int pageSize = DefaultSettings.PageSize, bool onlyActiveRentals = false)
        {
            PaginatedList<Rental> rentalsPaginatedList = await _rentalRepository.GetPaginatedListAsync(pageNumber, pageSize, x => x.UserId == userId && (!onlyActiveRentals || x.IsReturned == false), x => x.Book, x => x.User);

            PaginatedListDTO<RentalDTO> rentalsMappedPaginatedList = _mapper.Map<PaginatedListDTO<RentalDTO>>(rentalsPaginatedList);

            return rentalsMappedPaginatedList;
        }

        public async Task<PaginatedListDTO<RentalDTO>> GetRentalsPaginatedList(int pageNumber, int pageSize = DefaultSettings.PageSize, bool onlyActiveRentals = false)
        {
            PaginatedList<Rental> rentalsPaginatedList = await _rentalRepository.GetPaginatedListAsync(pageNumber, pageSize, x => (!onlyActiveRentals || x.IsReturned == false), x => x.Book, x => x.User);

            PaginatedListDTO<RentalDTO> rentalsMappedPaginatedList = _mapper.Map<PaginatedListDTO<RentalDTO>>(rentalsPaginatedList);

            return rentalsMappedPaginatedList;
        }
    }
}
