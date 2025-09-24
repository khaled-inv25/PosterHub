using Microsoft.EntityFrameworkCore;
using PosterHub.Domain.Catalog.Categories;
using PosterHub.EntityFramework.Configuration.Catalog;

namespace PosterHub.EntityFramework.AppDbContext
{
    public class PosterHubDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public PosterHubDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            //modelBuilder.ApplyConfiguration(new CategorySeed());
        }
    }
}
