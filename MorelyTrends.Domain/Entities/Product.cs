using MorelyTrends.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MorelyTrends.Domain.Entities
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string SKU { get; set; }
        public string Link { get; set; }
        public decimal Price { get; set; }
        public decimal RetailPrice { get; set; }
        public string SizeAndQuantity { get; set; }
        public string Note { get; set; }

        [ForeignKey("SellerId")]
        public int SellerId { get; set; }
        public Seller Seller { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    }
}
