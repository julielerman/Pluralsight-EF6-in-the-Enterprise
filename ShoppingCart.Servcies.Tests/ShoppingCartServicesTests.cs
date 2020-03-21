using System.Data.Entity;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Data;
using ShoppingCart.Domain;

namespace ShoppingCart.Services.Tests
{
  [TestClass]
  public class ShoppingCartServiceTests
  {
    private StringBuilder _logBuilder = new StringBuilder();
    private string _log;
    private ShoppingCartContext _context;
    private ReferenceContext _refContext;
    private string theUri = "http://www.thedatafarm.com";

    public ShoppingCartServiceTests() {
      _context = new ShoppingCartContext();
      _refContext=new ReferenceContext();

      Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ShoppingCartContext>());
    }

    [TestMethod]
    public void InitializeCartReturnsRevisitedCart() {
      //will add mocking later ...
      var service = new WebSiteOrderingService(new WebSiteOrderData(_context,_refContext));
      Assert.IsInstanceOfType(service.ItemSelected(1, 1, 9.99m, theUri, null,0), typeof(RevisitedCart));
    }

    [TestMethod]
    public void InitializeCartWithUnknownCustomerStoresZeroInCustomerId() {
      //will add mocking later ...
      var service = new WebSiteOrderingService(new WebSiteOrderData(_context,_refContext));
      SetupLogging();
      RevisitedCart cart = service.ItemSelected(1, 1, 9.99m, theUri, null,0);
      WriteLog();
      Assert.AreEqual(0, _context.Carts.Find(cart.CartId).CustomerId);
    }

    [TestMethod]
    public void InitializeCartWithKnownCustomerStoresValueInCustomerId() {
      //will add mocking later ...
      //this action begs for an external service or message queue to see if
      //CustomerCookieABCDE exists in test database
      //removed the code that inserted the data into the database
      var service = new WebSiteOrderingService(new WebSiteOrderData(_context, _refContext));
      SetupLogging();
      RevisitedCart cart = service.ItemSelected(1, 1, 9.99m, theUri, "CustomerCookieABCDE",0);
      WriteLog();
      Assert.AreNotEqual(0, _context.Carts.Find(cart.CartId).CustomerId);
    }

    private void WriteLog() {
      Debug.WriteLine(_log);
    }

    private void SetupLogging() {
      _context.Database.Log = BuildLogString;
    }

    private void BuildLogString(string message) {
      _logBuilder.Append(message);
      _log = _logBuilder.ToString();
    }
  }
}