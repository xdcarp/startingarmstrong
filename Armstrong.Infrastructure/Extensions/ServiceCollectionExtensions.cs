using Armstrong.Infrastructure.EFContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Armstrong.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppIdentityDbContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnString"),
                builder => builder.MigrationsAssembly(typeof(AppIdentityDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddScoped<DbContext, AppIdentityDbContext>();

            return services;
        }
    }
}
