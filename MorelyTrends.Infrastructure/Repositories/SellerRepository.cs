using MorelyTrends.Domain.Entities;
using MorelyTrends.Domain.Entities.Identity;
using MorelyTrends.Domain.Interfaces;
using MorelyTrends.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorelyTrends.Infrastructure.Repositories
{
    public class SellerRepository(MorelyTrendsDbContext dbContext, IRegisterRepository registerRepository) : ISellerRepository
    {
        public async Task<Seller> AddSeller(Seller seller, string password, string role)
        {
            var user = new ApplicationUser();

            user.UserName = seller.Email;
            user.Email = seller.Email;
            user.FirstName = seller.FirstName;
            user.LastName = seller.LastName;
            user.Gender = null;
            user.EmailConfirmed = true;
            user.PhoneNumberConfirmed = true;
            var newUser = await registerRepository.CreateUser(user, password, role);
            if (newUser.Succeeded) {
                seller.UserId = newUser.Data;
            await dbContext.Sellers.AddAsync(seller);
            await dbContext.SaveChangesAsync();
            return seller;
            }
            return seller;
        }
    }
}
