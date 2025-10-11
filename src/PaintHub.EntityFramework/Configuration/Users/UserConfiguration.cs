using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PosterHub.Domain.Users;

namespace PosterHub.EntityFramework.Configuration.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.RefreshToken).IsRequired(false);
        }
    }
}
