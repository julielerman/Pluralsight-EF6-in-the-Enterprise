using Order.Domain.ValueObjects;

namespace Order.Write.Domain.DTOs
{
  public class Customer
  {
    private Customer(int customerId, Address primaryAddress, CustomerStatus status)
    {
      CustomerId = customerId;
      PrimaryAddress = primaryAddress;
      Status = CustomerStatus.New;
    }

    public int CustomerId { get; private set; }
    public CustomerStatus Status { get; private set; }
    public Address PrimaryAddress { get; private set; }

    public static Customer Create(int customerId, Address primaryAddress, CustomerStatus status)
    {
      var customer = new Customer(customerId, primaryAddress, status);
      customer.PrimaryAddress = primaryAddress;
      return customer;
    }
  }
}