using KSTU.App.BLL.Interfaces;
using KSTU.App.BLL.Services;
using KSTU.App.Data.Interfaces;
using KSTU.App.Data.Repositories;
using KSTU.Web.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace KSTU.Web.StartupSettings
{
    public static class DIConfiguration
    {
        public static IServiceCollection ConfigureAppDI(this IServiceCollection services)
        {
            #region Services

            services.AddScoped<IUserService, UserService>();

            #endregion

            #region  Repositories

            services.AddScoped(typeof(IApplicationRepository<>), typeof(ApplicationRepository<>));

            #endregion

            return services;
        }
    }
}