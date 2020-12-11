using DDD.Base.Template.Infra.CrossCutting.Extensions.Mediator.PipelineBehavior;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace DDD.Base.Template.Infra.CrossCutting.Ioc
{
    public static class MediatorInjection
    {
        private static Assembly DomainAssembly => AppDomain.CurrentDomain.Load("DDD.Base.Template.Domain");

        public static void AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(DomainAssembly);

            AssemblyScanner
                .FindValidatorsInAssembly(DomainAssembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
