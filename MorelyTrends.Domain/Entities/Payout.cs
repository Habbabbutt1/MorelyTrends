using MorelyTrends.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MorelyTrends.Domain.Entities
{
    public class Payout : BaseEntity
    {
        public int Id { get; set; }

        public string PayoutMethod { get; set; }
        public string PayoutAccount { get; set; }

        [ForeignKey("SellerId")]
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
    }
}
