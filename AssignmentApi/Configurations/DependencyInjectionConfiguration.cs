using AssignmentApi.Services.Class;
using AssignmentApi.Services.Interface;

namespace Assignment.Api.ServiceCollectionConfigurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
            return services;
        }
    }
}
