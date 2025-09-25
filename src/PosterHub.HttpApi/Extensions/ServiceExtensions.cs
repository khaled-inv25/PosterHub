using Microsoft.EntityFrameworkCore;
using PosterHub.Admin.Application;
using PosterHub.Admin.Application.Contract;
using PosterHub.Domain;
using PosterHub.EntityFramework;
using PosterHub.EntityFramework.AppDbContext;
using PosterHub.Logger.Contract;

namespace PosterHub.HttpApi.Extensions
{
    public static class ServiceExtensions
    {
        private const string CONNECTION_STRING_KEY = "sqlConnection";

        public static void ConfigureCors(this IServiceCollection services) => 
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

        public static void IISConfiguration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, AdminLoggerManager>();

        public static void ConfigurRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }

        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IDomainManager, DomainManager>();
        }

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PosterHubDbContext>( opts =>
                opts.UseSqlServer(configuration.GetConnectionString(CONNECTION_STRING_KEY))
            );
        }
    }
}
