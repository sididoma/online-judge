using AutoMapper;
using KSTU.App.BLL.Helpers;
using KSTU.Web.Helpers;
using KSTU.Web.StartupSettings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KSTU.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var mappingCfg = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ApplicationMapperProfileWeb>();
                cfg.AddProfile<ApplicationMapperProfile>();
            });
            IMapper mapper = mappingCfg.CreateMapper();
            services.AddSingleton(mapper);

            services.AddCors();

            #region CustomConfigurions

            services.ConfigureJwt(Configuration);

            services.AddSwaggerGenCustom();

            services.ConfigureAppDI();

            #endregion

            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x =>
                x.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            #region CustomSettings

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "KSTU Online Judge API");
                c.RoutePrefix = string.Empty;
            });

            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
