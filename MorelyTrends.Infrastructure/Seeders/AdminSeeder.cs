using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MorelyTrends.Domain.Entities.Identity;
using MorelyTrends.Domain.Enums;
using MorelyTrends.Infrastructure.Data;
using System.Data;

namespace MorelyTrends.Infrastructure.Seeders
{
    public class AdminSeeder(MorelyTrendsDbContext appDbContext) : IAdminSeeder
    {
        public async Task Seed(IServiceProvider serviceProvider)
        {
            if (await appDbContext.Database.CanConnectAsync())
            {
                if (!appDbContext.Roles.Any()) 
                {
                    var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

                    var superAdmin = new ApplicationRole();
                    superAdmin.Name = Roles.SuperAdmin.ToString();
                    superAdmin.NormalizedName = Roles.SuperAdmin.ToString().ToUpper();
                    await roleManager.CreateAsync(superAdmin);

                    var admin = new ApplicationRole();
                    admin.Name = Roles.Seller.ToString();
                    admin.NormalizedName = Roles.Seller.ToString().ToUpper();
                    await roleManager.CreateAsync(admin);

                    var basic = new ApplicationRole();
                    basic.Name = Roles.Buyer.ToString();
                    basic.NormalizedName = Roles.Buyer.ToString().ToUpper();
                    await roleManager.CreateAsync(basic);
                }
                if (!appDbContext.Users.Any())
                {
                    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    var user = new ApplicationUser();

                    user.UserName = "superadmin";
                    user.Email = "habbabbutt1@gmail.com";
                    user.FirstName = "Super";
                    user.LastName = "Admin";
                    user.Gender = "Male";
                    user.EmailConfirmed = true;
                    user.PhoneNumberConfirmed = true;

                    if (appDbContext.Users.All(x => x.Id != user.Id))
                    {
                        var result = await userManager.FindByEmailAsync(user.Email);

                        if (result == null)
                        {
                            await userManager.CreateAsync(user, "123@Test");
                            await userManager.AddToRoleAsync(user, Roles.SuperAdmin.ToString());
                            await userManager.AddToRoleAsync(user, Roles.Seller.ToString());
                            await userManager.AddToRoleAsync(user, Roles.Buyer.ToString());
                        }
                    }
                }
            }
        }
    }
}
