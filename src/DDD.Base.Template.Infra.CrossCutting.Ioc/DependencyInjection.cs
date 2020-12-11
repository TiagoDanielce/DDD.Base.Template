using Microsoft.Extensions.DependencyInjection;
using System;

namespace DDD.Base.Template.Infra.CrossCutting.Ioc
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            //Domain Services

            //Repositories

            //Database

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
