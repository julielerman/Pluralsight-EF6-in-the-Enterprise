using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order.Domain.DTOs;
using Order.Domain.ValueObjects;

namespace Order.Domain.Tests
{
  [TestClass]
  public class OrderDomainTests
  {
    [TestMethod]
    public void NewSalesOrderHasCorrectCartItemData() {
      //Arrange
      var customer=Customer.Create(1,Address.Create("a","b","c","d"),CustomerStatus.New);
      var items = new List<CartItem> {new CartItem(1, 10, 5), new CartItem(2, 100, 5)};
      //Act
      var order = SalesOrder.Create(items, customer);
      //Assert
      Assert.AreEqual(10, order.LineItems.Sum(i=>i.Quantity));
      Assert.AreEqual(550, order.LineItems.Sum(i => i.LineTotal));
    }

    [TestMethod]
    public void NewSalesOrderHasCorrectShippingAddress() {
      //Arrange
      var customer = Customer.Create(1, Address.Create("a", "b", "c", "d"), CustomerStatus.New);
      var items = new List<CartItem> { new CartItem(1, 10, 5), new CartItem(2, 100, 5) };
      //Act
      var order = SalesOrder.Create(items, customer);
      //Assert
      Assert.AreEqual(Address.Create("a","b","c","d"),order.ShippingAddress);
     }
  }
}
