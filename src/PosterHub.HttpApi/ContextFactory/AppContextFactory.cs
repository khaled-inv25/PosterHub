using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PosterHub.EntityFramework.AppDbContext;

namespace PosterHub.HttpApi.ContextFactory
{
    // This class will help us create a DbContext instance during the design time.
    public class AppContextFactory : IDesignTimeDbContextFactory<PosterHubDbContext>
    {
        private const string CONNECTION_STRING_KEY = "sqlConnection";

        public PosterHubDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<PosterHubDbContext>()
                .UseSqlServer(configuration.GetConnectionString(CONNECTION_STRING_KEY), 
                b => b.MigrationsAssembly("PosterHub.HttpApi"));

            return new PosterHubDbContext(builder.Options);
        }
    }
}
