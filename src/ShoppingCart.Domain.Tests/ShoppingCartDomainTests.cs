using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcSalesApp.SharedKernel.Enums;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Domain.Tests
{
  [TestClass]
  public class ShoppingCartDomainTests
  {
    [TestMethod, TestCategory("ShoppingCart")]
    public void CanCreateRevisitedCartWithNoItems() {
      var cart = RevisitedCart.Create(1);

      Assert.AreEqual(1, cart.CartId);
    }

    [TestMethod, TestCategory("ShoppingCart")]
    public void CanCreateNewCartFromProductSelectionWithKnownCustomer() {
      var cart = NewCart.CreateCartFromProductSelection("http://www.thedatafarm.com", "customerCookieString", 1, 1, 9.99m);
      Assert.AreEqual(9.99m, cart.CartItems.Single().CurrentPrice);
    }

    [TestMethod, TestCategory("ShoppingCart")]
    public void CanCreateNewCartFromProductSelectionWithNoKnownCustomer() {
      var cart = NewCart.CreateCartFromProductSelection("http://thedatafarm.com", null, 1, 1, 9.99m);
      Assert.AreEqual(9.99m, cart.CartItems.Single().CurrentPrice);
    }

    [TestMethod, TestCategory("ShoppingCart")]
    public void CanInsertItemIntoEmptyRevisitedCart() {
      var cart = RevisitedCart.Create(1);
      cart.InsertNewCartItem(1, 1, 9.99m);
      Assert.AreEqual(1, cart.CartItems.Count());
    }

    [TestMethod, TestCategory("ShoppingCart")]
    public void CanCreateRevisitedCartWithExistingItems() {
      var cart = RevisitedCart.CreateWithItems(1, new List<CartItem> { CartItem.Create(1, 1, 9.99m, 1) });
      Assert.AreEqual(1, cart.CartItems.Count());
      Assert.AreEqual(9.99m, cart.CartItems.Single().CurrentPrice);
    }

    [TestMethod]
    public void ItemUpdateQuantityCanChangeStateToModified() {
      var cart = NewCart.CreateCartFromProductSelection("", null, 1, 1, 9.99m);
      cart.CartItems.First().UpdateQuantity(2);
      Assert.AreEqual(ObjectState.Modified, cart.CartItems.First().State);
    }
  }
}