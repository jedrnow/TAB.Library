using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TAB.Library.Backend.Core.Entities;

namespace TAB.Library.Backend.Infrastructure.Configurations
{
    public class BookThumbnailConfiguration : IEntityTypeConfiguration<BookThumbnail>
    {
        public void Configure(EntityTypeBuilder<BookThumbnail> builder)
        {
            builder.HasOne(r => r.Book)
                   .WithMany(b => b.BookThumbnails)
                   .HasForeignKey(r => r.BookId);
        }
    }
}
