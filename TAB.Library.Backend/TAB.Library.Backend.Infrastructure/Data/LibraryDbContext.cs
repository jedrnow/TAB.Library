using Microsoft.EntityFrameworkCore;

namespace TAB.Library.Backend.Infrastructure.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
