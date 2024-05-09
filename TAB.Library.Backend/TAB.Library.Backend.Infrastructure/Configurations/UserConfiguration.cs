using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TAB.Library.Backend.Core.Entities;

namespace TAB.Library.Backend.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasMany(u => u.UsersRentals)
               .WithOne(r => r.User)
               .HasForeignKey(r => r.UserId);

            builder.HasData(new User()
            {
                Id = 1,
                Username = "superadmin",
                Email = "jedrzej.nowaczyk00@gmail.com",
                FirstName = "Jędrzej",
                LastName = "Nowaczyk",
                PhoneNumber = "1234567890",
                RoleId = 1,
                PasswordHash = "7d948a6a6ea2e89d89645321e2df20d7ad859e7008acb8531f295b05f59b9a98",
                CreatedAtUtc = new DateTime(2024, 4, 25),
                UpdatedAtUtc = new DateTime(2024, 4, 25)
            });
        }
    }
}
