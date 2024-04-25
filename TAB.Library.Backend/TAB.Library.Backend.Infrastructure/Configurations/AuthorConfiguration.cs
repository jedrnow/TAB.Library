using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TAB.Library.Backend.Core.Entities;

namespace TAB.Library.Backend.Infrastructure.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasData(
                new Author { Id = 1, FirstName = "Andrzej", LastName = "Sapkowski", CreatedAtUtc = new DateTime(2024, 4, 25), UpdatedAtUtc = new DateTime(2024, 4, 25) },
                new Author { Id = 2, FirstName = "Brian", LastName = "Herbert", CreatedAtUtc = new DateTime(2024, 4, 25), UpdatedAtUtc = new DateTime(2024, 4, 25) },
                new Author { Id = 3, FirstName = "Remigiusz", LastName = "Mróz", CreatedAtUtc = new DateTime(2024, 4, 25), UpdatedAtUtc = new DateTime(2024, 4, 25) },
                new Author { Id = 4, FirstName = "Riley", LastName = "Sager", CreatedAtUtc = new DateTime(2024, 4, 25), UpdatedAtUtc = new DateTime(2024, 4, 25) },
                new Author { Id = 5, FirstName = "Vance", LastName = "Ashlee", CreatedAtUtc = new DateTime(2024, 4, 25), UpdatedAtUtc = new DateTime(2024, 4, 25) },
                new Author { Id = 6, FirstName = "Dougal", LastName = "Dixon", CreatedAtUtc = new DateTime(2024, 4, 25), UpdatedAtUtc = new DateTime(2024, 4, 25) },
                new Author { Id = 7, FirstName = "Antoni", LastName = "Dudek", CreatedAtUtc = new DateTime(2024, 4, 25), UpdatedAtUtc = new DateTime(2024, 4, 25) },
                new Author { Id = 8, FirstName = "David", LastName = "Goggins", CreatedAtUtc = new DateTime(2024, 4, 25), UpdatedAtUtc = new DateTime(2024, 4, 25) },
                new Author { Id = 9, FirstName = "Marek", LastName = "Wnukowski", CreatedAtUtc = new DateTime(2024, 4, 25), UpdatedAtUtc = new DateTime(2024, 4, 25) },
                new Author { Id = 10, FirstName = "Carl", LastName = "Barks", CreatedAtUtc = new DateTime(2024, 4, 25), UpdatedAtUtc = new DateTime(2024, 4, 25) },
                new Author { Id = 11, FirstName = "Stephen", LastName = "King", CreatedAtUtc = new DateTime(2024, 4, 25), UpdatedAtUtc = new DateTime(2024, 4, 25) },
                new Author { Id = 12, FirstName = "Stephen", LastName = "Hawking", CreatedAtUtc = new DateTime(2024, 4, 25), UpdatedAtUtc = new DateTime(2024, 4, 25) }
            );
        }
    }
}
