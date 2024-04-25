using TAB.Library.Backend.Core.Entities;
using TAB.Library.Backend.Infrastructure.Data;
using TAB.Library.Backend.Infrastructure.Repositories.Abstractions;

namespace TAB.Library.Backend.Infrastructure.Repositories
{
    public class CategoryRepository : EntityRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(LibraryDbContext context) : base(context)
        {
        }
    }
}
