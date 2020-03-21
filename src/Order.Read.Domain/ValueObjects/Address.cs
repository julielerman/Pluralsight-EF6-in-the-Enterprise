using MvcSalesApp.SharedKernel;

namespace Order.Domain.ValueObjects
{
  public class Address : ValueObject<Address>
  {
    public static Address Create(string street, string city, string stateProvince, string postalCode) {
      return new Address(street, city, stateProvince, postalCode);
    }
      private Address(string street, string city, string stateProvince, string postalCode)
    {
      Street = street;
      City = city;
      StateProvince = stateProvince;
      PostalCode = postalCode;
    }
    public Address() { } //need for EF queries

    public string Street { get; private set; }
    public string City { get; private set; }
    public string StateProvince { get; private set; }
    public string PostalCode { get; private set; }
  }
}