using CleanArchitectureTemplate.Core;
using CleanArchitectureTemplate.Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace CleanArchitectureTemplate.Web
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //Automapper injection
            services.AddAutoMapper(typeof(Program));

            services.AddInfrastructureDependencies(configuration);
            services.AddCoreDependencies(configuration);

            return services;
        }
    }
}
