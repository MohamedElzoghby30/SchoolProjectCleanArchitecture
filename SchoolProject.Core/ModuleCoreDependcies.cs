using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Core.Behavior;
using FluentValidation;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Implemention;
using System.Reflection;

namespace SchoolProject.Core
{
    public static class ModuleCoreDependcies
    {
        public static IServiceCollection AddModuleCoreDependcies(this IServiceCollection services)
        {

            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
