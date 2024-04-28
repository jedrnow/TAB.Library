using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TAB.Library.Backend.Core.Entities;

namespace TAB.Library.Backend.Infrastructure.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            builder
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId);

            builder
                .HasOne(b => b.BookFile)
                .WithOne(bf => bf.Book)
                .HasForeignKey<Book>(b => b.BookFileId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Book { Id = 1, Title = "Wiedźmin", PublishYear = 1986, CategoryId = 1, AuthorId = 1, CreatedAtUtc = new DateTime(2024, 4, 28), UpdatedAtUtc = new DateTime(2024, 4, 28) },
                new Book { Id = 2, Title = "Diuna. Krucjata przeciw maszynom", PublishYear = 2003, CategoryId = 2, AuthorId = 2, CreatedAtUtc = new DateTime(2024, 4, 28), UpdatedAtUtc = new DateTime(2024, 4, 28) },
                new Book { Id = 3, Title = "Behawiorysta", PublishYear = 2016, CategoryId = 3, AuthorId = 3, CreatedAtUtc = new DateTime(2024, 4, 28), UpdatedAtUtc = new DateTime(2024, 4, 28) },
                new Book { Id = 4, Title = "Dom po drugiej stronie jeziora", PublishYear = 2022, CategoryId = 4, AuthorId = 4, CreatedAtUtc = new DateTime(2024, 4, 28), UpdatedAtUtc = new DateTime(2024, 4, 28) },
                new Book { Id = 5, Title = "Elon Musk. Biografia twórcy PayPala, Tesli i SpaceX", PublishYear = 2016, CategoryId = 5, AuthorId = 5, CreatedAtUtc = new DateTime(2024, 4, 28), UpdatedAtUtc = new DateTime(2024, 4, 28) },
                new Book { Id = 6, Title = "Dinozaury. Encyklopedia", PublishYear = 2023, CategoryId = 6, AuthorId = 6, CreatedAtUtc = new DateTime(2024, 4, 28), UpdatedAtUtc = new DateTime(2024, 4, 28) },
                new Book { Id = 7, Title = "Historia polityczna Polski 1989-2023", PublishYear = 2023, CategoryId = 7, AuthorId = 7, CreatedAtUtc = new DateTime(2024, 4, 28), UpdatedAtUtc = new DateTime(2024, 4, 28) },
                new Book { Id = 8, Title = "Nic mnie nie złamie. Zapanuj nad swoim umysłem i pokonaj przeciwności losu", PublishYear = 2023, CategoryId = 8, AuthorId = 8, CreatedAtUtc = new DateTime(2024, 4, 28), UpdatedAtUtc = new DateTime(2024, 4, 28) },
                new Book { Id = 9, Title = "Czarek. Żołnierz Zakonu Ziemskiej Magii", PublishYear = 2023, CategoryId = 9, AuthorId = 9, CreatedAtUtc = new DateTime(2024, 4, 28), UpdatedAtUtc = new DateTime(2024, 4, 28) },
                new Book { Id = 10, Title = "Kaczogród. Dotyk Midasa i inne historie z lat 1961–1962", PublishYear = 2024, CategoryId = 10, AuthorId = 10, CreatedAtUtc = new DateTime(2024, 4, 28), UpdatedAtUtc = new DateTime(2024, 4, 28) },
                new Book { Id = 11, Title = "Zielona mila", PublishYear = 2023, CategoryId = 11, AuthorId = 11, CreatedAtUtc = new DateTime(2024, 4, 28), UpdatedAtUtc = new DateTime(2024, 4, 28) },
                new Book { Id = 12, Title = "Krótkie odpowiedzi na wielkie pytania", PublishYear = 2023, CategoryId = 12, AuthorId = 12, CreatedAtUtc = new DateTime(2024, 4, 28), UpdatedAtUtc = new DateTime(2024, 4, 28) }
            );
        }
    }
}
