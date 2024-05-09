using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TAB.Library.Backend.Core.Entities;

namespace TAB.Library.Backend.Infrastructure.Data
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookFile> BookFiles { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
