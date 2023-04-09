using CleanArchitectureTemplate.Infrastructure.Abstractions.Repositories;
using CleanArchitectureTemplate.Infrastructure.Contexts;
using CleanArchitectureTemplate.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Contrib.WaitAndRetry;
using System.Diagnostics.CodeAnalysis;

namespace CleanArchitectureTemplate.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //Databases injection
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("Database")));

            //Repositories injection
            services.AddScoped<IUserRepository, UserRepository>();


            services.AddHttpClient("ClientName")
            .AddTransientHttpErrorPolicy(
                policyBuilder => policyBuilder.WaitAndRetryAsync(
                    Backoff.DecorrelatedJitterBackoffV2(
                        TimeSpan.FromSeconds(1),
                        int.Parse(configuration["ClientSettings:RetryCount"])
                    )
                )
            );

            return services;
        }
    }
}
