using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infastructure.Abstracts;
using SchoolProject.Infastructure.Repositories;
using SchoolProject.Service.Abstracts;
using SchoolProject.Service.Implemention;

namespace SchoolProject.Service
{
    public static class ModuleServiceDependcies
    {
        public static IServiceCollection AddServiceDependcies(this IServiceCollection services)
        {

            services.AddTransient<IStudentService, StudentService>();

            return services;
        }

    }
}
