using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TAB.Library.Backend.Core.Entities;

namespace TAB.Library.Backend.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(c => c.Books).WithOne(b => b.Category).HasForeignKey(b => b.CategoryId);

            builder.HasData(
                new Category { Id = 1, Name = "Fantasy", CreatedAtUtc = new DateTime(2024,4,25), UpdatedAtUtc = new DateTime(2024, 4, 25) },
                new Category { Id = 2, Name = "Science fiction", CreatedAtUtc = new DateTime(2024, 4, 25), UpdatedAtUtc = new DateTime(2024, 4, 25) },
                new Category { Id = 3, Name = "Kryminał", CreatedAtUtc = new DateTime(2024, 4, 25), UpdatedAtUtc = new DateTime(2024, 4, 25) },
                new Category { Id = 4, Name = "Thriller", CreatedAtUtc = new DateTime(2024,4,25), UpdatedAtUtc = new DateTime(2024, 4, 25) },
                new Category { Id = 5, Name = "Biografia", CreatedAtUtc = new DateTime(2024,4,25), UpdatedAtUtc = new DateTime(2024, 4, 25) },
                new Category { Id = 6, Name = "Encyklopedia", CreatedAtUtc = new DateTime(2024,4,25), UpdatedAtUtc = new DateTime(2024, 4, 25) },
                new Category { Id = 7, Name = "Historia", CreatedAtUtc = new DateTime(2024,4,25), UpdatedAtUtc = new DateTime(2024, 4, 25) },
                new Category { Id = 8, Name = "Poradnik", CreatedAtUtc = new DateTime(2024,4,25), UpdatedAtUtc = new DateTime(2024, 4, 25) },
                new Category { Id = 9, Name = "Bajka", CreatedAtUtc = new DateTime(2024,4,25), UpdatedAtUtc = new DateTime(2024, 4, 25) },
                new Category { Id = 10, Name = "Komiks", CreatedAtUtc = new DateTime(2024,4,25), UpdatedAtUtc = new DateTime(2024, 4, 25) },
                new Category { Id = 11, Name = "Horror", CreatedAtUtc = new DateTime(2024,4,25), UpdatedAtUtc = new DateTime(2024, 4, 25) },
                new Category { Id = 12, Name = "Popularnonaukowa", CreatedAtUtc = new DateTime(2024, 4, 25), UpdatedAtUtc = new DateTime(2024, 4, 25) }
            );
        }
    }
}
