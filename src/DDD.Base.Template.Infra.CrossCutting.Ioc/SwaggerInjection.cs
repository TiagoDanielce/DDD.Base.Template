using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace DDD.Base.Template.Infra.CrossCutting.Ioc
{
    public static class SwaggerInjection
    {
        public static void AddSwagger(this IServiceCollection services, Assembly apiAssembly)
        {
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Api DDD Base Template",
                        Description = "Template base criado como resultado de estudo",
                        Contact = new OpenApiContact
                        {
                            Name = "Template"
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Use under LICX"
                        }
                    });

                    var xmlFile = $"{apiAssembly.GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    options.IncludeXmlComments(xmlPath);

                    options.AddSecurityDefinition(
                        "Bearer",
                        new OpenApiSecurityScheme
                        {
                            Description = "Header de autorização JWT usando esquema Bearer.",
                            Type = SecuritySchemeType.Http,
                            Scheme = "bearer"
                        }
                    );

                    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Id = "Bearer",
                                    Type = ReferenceType.SecurityScheme
                                }
                            },
                            new List<string>()
                        }
                    });
                }
            );
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(configuration["SwaggerEndpoint"], "API");
                c.RoutePrefix = "swagger";
            });
        }
    }
}
