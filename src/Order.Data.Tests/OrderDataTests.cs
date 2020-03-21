using Microsoft.VisualStudio.TestTools.UnitTesting;
using Order.Domain;
using Order.Domain.DTOs;
using Order.Domain.ValueObjects;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Order.Data.Tests
{
  [TestClass]
  public class OrderDataTests
  {
    private string _log;
    private StringBuilder _logBuilder = new StringBuilder();

    public OrderDataTests() {
      Database.SetInitializer(new NullDatabaseInitializer<OrderContext>());
    }

    [TestMethod]
    public void CanPersistShippingAddressWithOrder() {
      //Arrange
      var address = Address.Create("a", "b", "c", "d");
      var customer = Customer.Create(1, address, CustomerStatus.New);
      var items = new List<CartItem> {new CartItem(1, 10, 5), new CartItem(2, 100, 5)};

      //Act
      var order = SalesOrder.Create(items, customer);
      using (var context = new OrderContext())
      {
        SetupLogging(context);
        context.Orders.Add(order);
        context.SaveChanges();
      }
      //Assert
      using (var context = new OrderContext())
      {
        SetupLogging(context);
        var databaseOrder = context.Orders.FirstOrDefault();
        Assert.AreEqual(address, databaseOrder.ShippingAddress);
        WriteLog();
      }
    }

    private void WriteLog()
    {
      Debug.WriteLine(_log);
    }

    private void SetupLogging(DbContext context)
    {
      context.Database.Log = BuildLogString;
    }

    private void BuildLogString(string message)
    {
      _logBuilder.Append(message);
      _log = _logBuilder.ToString();
    }
  }
}