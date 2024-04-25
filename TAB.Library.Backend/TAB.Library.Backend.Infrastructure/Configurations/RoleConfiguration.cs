using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TAB.Library.Backend.Core.Entities;

namespace TAB.Library.Backend.Infrastructure.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role { Id = 1, Name = "Administrator", CreatedAtUtc = new DateTime(2024, 4, 25), UpdatedAtUtc = new DateTime(2024, 4, 25) },
                new Role { Id = 2, Name = "User", CreatedAtUtc = new DateTime(2024, 4, 25), UpdatedAtUtc = new DateTime(2024, 4, 25) }
            );
        }
    }
}
