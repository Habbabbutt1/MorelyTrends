using MorelyTrends.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorelyTrends.Domain.Interfaces
{
    public interface ISellerRepository
    {
        Task<Seller> AddSeller(Seller seller, string password, string role);
    }
}
