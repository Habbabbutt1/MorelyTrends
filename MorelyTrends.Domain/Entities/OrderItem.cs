using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorelyTrends.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }  // Many-to-One relationship with Order
        public int ProductId { get; set; }
        //public Product Product { get; set; }  // Many-to-One relationship with Product
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
