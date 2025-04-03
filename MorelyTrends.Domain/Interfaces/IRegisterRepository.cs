using MorelyTrends.Domain.Entities;
using MorelyTrends.Domain.Entities.Common;
using MorelyTrends.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorelyTrends.Domain.Interfaces
{
    public interface IRegisterRepository
    {
        Task<IdentityResponse> CreateUser(ApplicationUser user, string password, string role);
    }
}
