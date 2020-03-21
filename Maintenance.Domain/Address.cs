using Maintenance.Domain.Enums;

namespace Maintenance.Domain
{
  public class Address
  {
    public int AddressId { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string StateProvince { get; set; }
    public string PostalCode { get; set; }
    public AddressType AddressType { get; set; }
    public int CustomerId { get; set; }

    public Customer Customer { get; set; }
  }
} 