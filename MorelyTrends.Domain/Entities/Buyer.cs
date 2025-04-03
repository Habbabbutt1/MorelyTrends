namespace MorelyTrends.Domain.Entities
{
    public class Buyer
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        //public User User { get; set; }  // One-to-One relationship with User
        public ICollection<Order> Orders { get; set; }
    }
}
