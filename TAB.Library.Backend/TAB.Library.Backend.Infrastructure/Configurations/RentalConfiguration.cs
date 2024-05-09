using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TAB.Library.Backend.Core.Entities;

namespace TAB.Library.Backend.Infrastructure.Configurations
{
    public class RentalConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.HasOne(r => r.Book)
                   .WithMany(b => b.RentalHistory)
                   .HasForeignKey(r => r.BookId);

            builder.HasOne(r => r.User)
                   .WithMany(u => u.UsersRentals)
                   .HasForeignKey(r => r.UserId);
        }
    }
}
