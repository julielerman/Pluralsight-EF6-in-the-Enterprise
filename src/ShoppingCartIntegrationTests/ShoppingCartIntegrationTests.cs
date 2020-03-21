using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharedKernel.Data;
using ShoppingCart.Domain;

namespace ShoppingCart.Data.Tests
{
  [TestClass]
  public class ShoppingCartIntegrationTests
  {
    private readonly string _theUri = "http://www.thedatafarm.com";
    private ShoppingCartContext _context;
    private string _log;
    private StringBuilder _logBuilder = new StringBuilder();
    private ReferenceContext _refContext;

    public ShoppingCartIntegrationTests() {
      //app.config points to a special testing database:GeekSalesStuffTester
      Database.SetInitializer(new DropCreateDatabaseAlways<ShoppingCartContext>());
      _context = new ShoppingCartContext();
      _refContext = new ReferenceContext();
      _context.Database.Initialize(true); //get this out of the way before logging
      SetupLogging();
    }

    [TestMethod]
    public void CanAddNewCartWithProductToCartsDbSet() {
      var cart = NewCart.CreateCartFromProductSelection(_theUri, null, 1, 1, 9.99m);
      _context.Carts.Add(cart);
      Assert.AreEqual(1, _context.Carts.Local.Count);
    }

    [TestMethod]
    public void CanStoreCartWithInitialProduct() {
      var cart = NewCart.CreateCartFromProductSelection(_theUri, null, 1, 1, 9.99m);
      var data = new WebSiteOrderData(_context, _refContext);
      var resultCart = data.StoreCartWithInitialProduct(cart);
      WriteLog();
      Assert.AreNotEqual(0, resultCart.CartId);
    }

    [TestMethod]
    public void CanUpdateCartItems() {
      //Arrange
      var data1 = new WebSiteOrderData(_context, _refContext);
      var cartId = SeedCartAndReturnId(data1);
      var existingCart = data1.RetrieveCart(cartId);
      var lineItemCount = existingCart.CartItems.Count();
      var firstItem = existingCart.CartItems.First();
      var originalTotalItems = existingCart.TotalItems;
      var originalQuantity = firstItem.Quantity;
      existingCart.CartItems.First().UpdateQuantity(originalQuantity + 1);
      existingCart.InsertNewCartItem(1, 1, new decimal(100));
      //Act
      var data2 = new WebSiteOrderData(new ShoppingCartContext(), _refContext);
      data2.UpdateItemsForExistingCart(existingCart);
      //Assert
      var data3 = new WebSiteOrderData(new ShoppingCartContext(), _refContext);
      var existingCartAgain = data3.RetrieveCart(cartId);
      Assert.AreEqual(lineItemCount + 1, existingCartAgain.CartItems.Count());
      Assert.AreEqual(originalTotalItems + 2, existingCartAgain.TotalItems);
    }

    [TestMethod]
    public void FixStateCanInterpretLocalState() {
      var cart = NewCart.CreateCartFromProductSelection(_theUri, null, 1, 1, 9.99m);
      cart.CartItems.First().UpdateQuantity(2);
      _context.Carts.Attach(cart);
      _context.FixState();
      Assert.AreEqual(EntityState.Unchanged, _context.Entry(cart).State);
      Assert.AreEqual(EntityState.Modified, _context.Entry(cart.CartItems.First()).State);
    }

    [TestMethod]
    public void CanRetrieveCartFromRepoUsingCartId() {
      //note if you want to dropcreate the db do it before context creation
      var repo = new WebSiteOrderData(_context, _refContext);
      var id = SeedCartAndReturnId(repo);
      Debug.WriteLine($"Stored Cart Id from database {id}");
      Assert.AreEqual(id, repo.RetrieveCart(id).CartId);
    }

    private int SeedCartAndReturnId(WebSiteOrderData repo) {
      var cart = NewCart.CreateCartFromProductSelection(_theUri, null, 1, 1, 9.99m);
      var createdCart = repo.StoreCartWithInitialProduct(cart);
      return createdCart.CartId;
    }

    private void WriteLog()
    {
      Debug.WriteLine(_log);
    }

    private void SetupLogging()
    {
      _context.Database.Log = BuildLogString;
    }

    private void BuildLogString(string message)
    {
      _logBuilder.Append(message);
      _log = _logBuilder.ToString();
    }
  }
}