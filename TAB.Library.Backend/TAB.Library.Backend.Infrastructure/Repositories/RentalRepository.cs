using TAB.Library.Backend.Core.Entities;
using TAB.Library.Backend.Infrastructure.Data;
using TAB.Library.Backend.Infrastructure.Repositories.Abstractions;

namespace TAB.Library.Backend.Infrastructure.Repositories
{
    public class RentalRepository : EntityRepository<Rental>, IRentalRepository
    {
        public RentalRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
