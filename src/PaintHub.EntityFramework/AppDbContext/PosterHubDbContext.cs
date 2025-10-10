using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PosterHub.Domain.Catalog.Categories;
using PosterHub.Domain.Users;
using PosterHub.EntityFramework.Configuration.Catalog;
using PosterHub.EntityFramework.Configuration.Users;

namespace PosterHub.EntityFramework.AppDbContext
{
    public class PosterHubDbContext : IdentityDbContext<User>
    {
        public DbSet<Category> Categories { get; set; }

        public PosterHubDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            //modelBuilder.ApplyConfiguration(new CategorySeed());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
