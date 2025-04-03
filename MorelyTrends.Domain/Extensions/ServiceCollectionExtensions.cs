using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MorelyTrends.Domain.Options;

namespace MorelyTrends.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStringOptions>(configuration.GetSection(ConnectionStringOptions.SectionName));

            return services;
        }
    }
}
