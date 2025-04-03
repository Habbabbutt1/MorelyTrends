using System.ComponentModel.DataAnnotations;

public class SellerAddressDto
{
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string City { get; set; }
    public string Postcode { get; set; }
}