using System.ComponentModel.DataAnnotations;

namespace MorelyTrends.Application.DTOs
{
    public class CreateEditSellerDto
    {
        public int? Id { get; set; } // Nullable for distinguishing create vs. edit

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = "Seller"; // Default role as "Seller"

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        public string Password { get; set; } = string.Empty;

        public SellerAddressDto Address { get; set; }
    }
}