using MorelyTrends.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace MorelyTrends.Domain.Entities
{
    public class Seller
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public SellerAddress Address { get; set; }

        public ICollection<Payout> Payouts { get; set; } = new List<Payout>();

        public ICollection<Product> Products { get; set; } = new List<Product>();

        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
