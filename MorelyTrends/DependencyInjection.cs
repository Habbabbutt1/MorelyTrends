using MorelyTrends.Application.Extensions;
using MorelyTrends.Infrastructure.Extensions;

namespace MorelyTrends.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplication()
                .AddInfrastructure()
                .AddDomainDI(configuration);

            return services;
        }
    }
}
