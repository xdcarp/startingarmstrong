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
            var provider = "SQLite";
            services.AddDbContext<AppIdentityDbContext>(
                options => _ = provider switch
                {
                    "SqlServer" => options.UseSqlServer(configuration.GetConnectionString("DefaultConnString"),
                                    builder => builder.MigrationsAssembly(typeof(AppIdentityDbContext).Assembly.FullName)),
                    "SQLite" => options.UseSqlite(@"Data Source=identity.db", builder => builder.MigrationsAssembly(typeof(AppIdentityDbContext).Assembly.FullName)),
                    _ => throw new Exception($"Unsupported provider: {provider}")
                }, ServiceLifetime.Transient);

            services.AddScoped<DbContext, AppIdentityDbContext>();

            return services;
        }
    }
}
