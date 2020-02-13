using Microsoft.AspNetCore.Builder;

namespace KSTU.Web.StartupSettings
{
    public static class EndpointsSettings
    {
        public static IApplicationBuilder UseEndpointsCustom(this IApplicationBuilder builder)
        {
            return builder.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}