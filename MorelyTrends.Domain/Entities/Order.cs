using MorelyTrends.Domain.Entities.Common;

namespace MorelyTrends.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DeliveryCharge { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public int BuyerId { get; set; }
        public Buyer Buyer { get; set; }  // Many-to-One relationship with Buyer
        public int SellerId { get; set; }
        public Seller Seller { get; set; }  // Many-to-One relationship with Seller
        //public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public ICollection<OrderItem> OrderItems { get; set; }
        //public Payment Payment { get; set; }  // One-to-One relationship with Payment
    }
}
