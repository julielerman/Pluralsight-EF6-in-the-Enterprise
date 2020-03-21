using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart.Domain
{
  public class RevisitedCart
  {

    public static RevisitedCart CreateWithItems(int cartId, ICollection<CartItem> cartItems) {
      return new RevisitedCart(cartId, cartItems.ToList());
    }

    public static RevisitedCart Create(int cartId) {
      return new RevisitedCart(cartId, new List<CartItem>());
    }

    private RevisitedCart(int cartId, List<CartItem> cartItems) {
      CartId = cartId;
      _cartItems = new List<CartItem>();
      cartItems.ForEach(i => _cartItems.Add(i));
      UpdateItemCount();
    }

    private void UpdateItemCount() {
      _totalItems = _cartItems.Sum(i => i.Quantity);
    }

    public int CartId { get; private set; }
    public string CartCookie { get; private set; }
    public DateTime CartCookieExpires { get; private set; }
    private ICollection<CartItem> _cartItems; 
    public IEnumerable<CartItem> CartItems => _cartItems; //changed the getter to a C#6 expression body

    private int _totalItems;
    public int TotalItems => _totalItems;

    public CartItem InsertNewCartItem(int productId, int quantity, decimal displayedPrice) {
      var item = CartItem.Create(productId, quantity, displayedPrice, CartId);
      _cartItems.Add(item);
      UpdateItemCount();
      return item;
    }

    public void SetCookieData(string cartCookie, DateTime expiresDate) {
      CartCookie = cartCookie;
      CartCookieExpires = expiresDate;
    }

    public void ModifyCartItemQuantity(int itemId, int quantity) {
      var item = CartItems.Single(c => c.CartItemId == itemId);
      item.UpdateQuantity(quantity);
      UpdateItemCount();
    }
  }
}