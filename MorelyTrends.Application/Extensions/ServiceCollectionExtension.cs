using Microsoft.Extensions.DependencyInjection;

namespace MorelyTrends.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

        services.AddAutoMapper(applicationAssembly);

        //services.AddValidatorsFromAssembly(applicationAssembly)
        //    .AddFluentValidationAutoValidation();

        //services.AddScoped<IUserContext, UserContext>();

        //services.AddHttpContextAccessor();
        return services;
    }
}