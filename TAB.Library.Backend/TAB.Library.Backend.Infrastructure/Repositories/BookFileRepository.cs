using TAB.Library.Backend.Core.Entities;
using TAB.Library.Backend.Infrastructure.Data;
using TAB.Library.Backend.Infrastructure.Repositories.Abstractions;

namespace TAB.Library.Backend.Infrastructure.Repositories
{
    public class BookFileRepository : EntityRepository<BookFile>, IBookFileRepository
    {
        public BookFileRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
