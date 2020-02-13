using KSTU.App.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace KSTU.Web.StartupSettings
{
    public static class DataBasesConfiguration
    {
        public static IServiceCollection ConfigureDataBases(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(cfg =>
            {
                cfg
                    .UseNpgsql(configuration.GetConnectionString(configuration.GetConnectionString("ApplicationConnection")),
                        x => x.MigrationsAssembly("KSTU.App.Data"));
            });

            return services;
        }
    }
}