using CleanArchitectureTemplate.Core.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace CleanArchitectureTemplate.Core
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(x =>
            {
                x.Lifetime = ServiceLifetime.Scoped;
                x.RegisterServicesFromAssemblyContaining<ICoreMarker>();
            });

            return services;
        }
    }
}
