using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TAB.Library.Backend.Core.Entities;

namespace TAB.Library.Backend.Infrastructure.Configurations
{
    public class BookFileConfiguration : IEntityTypeConfiguration<BookFile>
    {
        public void Configure(EntityTypeBuilder<BookFile> builder)
        {
            builder
                .HasOne(bf => bf.Book)
                .WithOne(b => b.BookFile)
                .HasForeignKey<BookFile>(bf => bf.BookId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
