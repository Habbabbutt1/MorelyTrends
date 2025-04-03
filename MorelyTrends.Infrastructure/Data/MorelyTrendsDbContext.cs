using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MorelyTrends.Domain.Entities;
using MorelyTrends.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorelyTrends.Infrastructure.Data
{
    public class MorelyTrendsDbContext(DbContextOptions<MorelyTrendsDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, string>(options)
    {
        public DbSet<Seller> Sellers { get; set; }

        public DbSet<SellerAddress> SellerAddresses { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<Payout> Payouts { get; set; }

        public DbSet<Order> Orders { get; set; }


        public DbSet<OrderItem> OrdersItems { get; set; }

    }
}
