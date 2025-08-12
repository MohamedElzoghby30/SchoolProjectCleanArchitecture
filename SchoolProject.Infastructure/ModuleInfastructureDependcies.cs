using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infastructure.Abstracts;
using SchoolProject.Infastructure.InfastructureBasic;
using SchoolProject.Infastructure.Repositories;

namespace SchoolProject.Infastructure
{
    public static class ModuleInfastructureDependcies
    {
        public static IServiceCollection AddInfastructureDependcies(this IServiceCollection services)
        {

           services.AddTransient<IStudentRepository, StudentRepository>();
           services.AddTransient<ISubjectRepository, SubjectRepository>();
           services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            return services;
        }
    }
}
