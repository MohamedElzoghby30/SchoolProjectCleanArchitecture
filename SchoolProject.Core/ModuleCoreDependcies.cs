using Microsoft.Extensions.DependencyInjection;
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
            return services;
        }
    }
}
