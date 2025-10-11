using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PosterHub.EntityFramework.Configuration.Users
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "a1c5b8f4-7e2d-4e35-9b31-2d8b5a7d7a42",
                    ConcurrencyStamp = "ec511bd4-4853-426a-a2fc-751886560c9a",
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                },
                new IdentityRole
                {
                    Id = "b9e2d6a1-3c7f-4f8a-90ef-12a1fbc9e815",
                    ConcurrencyStamp = "937e9988-9f49-4bab-a545-b422dde85016",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                }
            );

        }
    }
}
