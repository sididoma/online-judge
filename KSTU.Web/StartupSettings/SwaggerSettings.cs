using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace KSTU.Web.StartupSettings
{
    public static class SwaggerSettings
    {
        public static IServiceCollection AddSwaggerGenCustom(this IServiceCollection services)
        {
            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "KSTU Online Judge API",
                    Version = "v1.0.0.1",
                    Description = "KSTU Online Judge API",
                    Contact = new OpenApiContact
                    {
                        Name = "Arstanbek Tashiev",
                        Email = "sididoma123@gmail.com",
                        Url = null
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                            BearerFormat = "JWT"
                            },
                            new List<string>()
                        }
                        });


                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = $"{AppContext.BaseDirectory}{xmlFile}";
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}