using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MorelyTrends.Domain.Entities;
using MorelyTrends.Domain.Entities.Identity;
using MorelyTrends.Domain.Interfaces;
using MorelyTrends.Domain.Options;
using MorelyTrends.Infrastructure.Data;
using MorelyTrends.Infrastructure.Repositories;
using MorelyTrends.Infrastructure.Seeders;
using System;

namespace MorelyTrends.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<MorelyTrendsDbContext>((provider, options) =>
            {
                options.UseSqlServer(provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value.DefaultConnection);
            });

            services.AddIdentityCore<ApplicationUser>()
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<MorelyTrendsDbContext>();

            services.AddScoped<IAdminSeeder, AdminSeeder>();
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.AddScoped<IRegisterRepository, RegisterRepository>();

            return services;
        }
    }
}
