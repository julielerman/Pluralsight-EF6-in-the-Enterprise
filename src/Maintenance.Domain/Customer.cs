using System;
using System.Collections.Generic;

namespace Maintenance.Domain
{
  public class Customer
  {
    private ICollection<Address> _addresses;
    private ICollection<Order> _orders;

    public Customer()
    {
      FirstName = "";
      LastName = "";
      DateOfBirth = DateTime.Today;
      _orders = new List<Order>();
      _addresses = new List<Address>();
    }

    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public ContactDetail ContactDetail { get; set; }

    public ICollection<Order> Orders
    {
      get { return _orders; }
      set { _orders = value; }
    }

    public ICollection<Address> Addresses
    {
      get { return _addresses; }
      set { _addresses = value; }
    }

    public string FullName
    {
      get { return LastName.Trim() + ", " + FirstName; }
    }

    public string CustomerCookie { get; set; }
  }
}