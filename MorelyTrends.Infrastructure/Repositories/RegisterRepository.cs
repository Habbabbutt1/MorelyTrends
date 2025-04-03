using Microsoft.AspNetCore.Identity;
using MorelyTrends.Domain.Entities;
using MorelyTrends.Domain.Entities.Common;
using MorelyTrends.Domain.Entities.Identity;
using MorelyTrends.Domain.Interfaces;
using MorelyTrends.Infrastructure.Data;
using MorelyTrends.Infrastructure.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorelyTrends.Infrastructure.Repositories
{
    public class RegisterRepository(MorelyTrendsDbContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager) : IRegisterRepository
    {
        public async Task<IdentityResponse> CreateUser(ApplicationUser user, string password, string role)
        {
            var existingUser = await userManager.FindByEmailAsync(user.Email);
            if (existingUser != null) {
                return IdentityResponse.Fail("User Already Exist");
            }
            if (await roleManager.RoleExistsAsync(role))
            {
                var createdUser = await userManager.CreateAsync(user, password);
                if (createdUser.Succeeded) {
                    await userManager.AddToRoleAsync(user, role);
                    return IdentityResponse.Success("User Created", user.Id);

                }
            }
            return IdentityResponse.Fail();
        }

        private string CreateRandomPassword()
        {
            var passwordComplexitySetting = new
            {
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true,
                RequiredLength = 6
            };
            var upperCaseLetters = "ABCDEFGHJKLMNOPQRSTUVWXYZ";
            var lowerCaseLetters = "abcdefghijkmnopqrstuvwxyz";
            var digits = "0123456789";
            var nonAlphanumerics = "!@$?_-";

            string[] randomChars =
            {
                upperCaseLetters,
                lowerCaseLetters,
                digits,
                nonAlphanumerics
            };

            var rand = new Random(Environment.TickCount);
            var chars = new List<char>();

            if (passwordComplexitySetting.RequireUppercase)
            {
                chars.Insert(rand.Next(0, chars.Count),
                    upperCaseLetters[rand.Next(0, upperCaseLetters.Length)]
                );
            }

            if (passwordComplexitySetting.RequireLowercase)
            {
                chars.Insert(rand.Next(0, chars.Count),
                    lowerCaseLetters[rand.Next(0, lowerCaseLetters.Length)]
                );
            }

            if (passwordComplexitySetting.RequireDigit)
            {
                chars.Insert(rand.Next(0, chars.Count),
                    digits[rand.Next(0, digits.Length)]
                );
            }

            if (passwordComplexitySetting.RequireNonAlphanumeric)
            {
                chars.Insert(rand.Next(0, chars.Count),
                    nonAlphanumerics[rand.Next(0, nonAlphanumerics.Length)]
                );
            }

            for (var i = chars.Count; i < passwordComplexitySetting.RequiredLength; i++)
            {
                var rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]
                );
            }

            return new string(chars.ToArray());
        }
    }
}
