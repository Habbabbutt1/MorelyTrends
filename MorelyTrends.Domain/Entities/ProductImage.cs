using MorelyTrends.Domain.Entities.Common;

namespace MorelyTrends.Domain.Entities;
public class ProductImage : BaseEntity
{
    public int Id { get; set; }
    public string ImageUrl { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
}