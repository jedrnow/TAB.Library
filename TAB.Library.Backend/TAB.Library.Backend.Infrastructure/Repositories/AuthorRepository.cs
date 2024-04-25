using TAB.Library.Backend.Core.Entities;
using TAB.Library.Backend.Infrastructure.Data;
using TAB.Library.Backend.Infrastructure.Repositories.Abstractions;

namespace TAB.Library.Backend.Infrastructure.Repositories
{
    public class AuthorRepository : EntityRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
