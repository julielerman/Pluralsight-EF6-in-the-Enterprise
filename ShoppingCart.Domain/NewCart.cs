using System;
using System.Collections.Generic;
using MvcSalesApp.SharedKernel.Settings;

namespace ShoppingCart.Domain
{
  public class NewCart : INewCart
  {
    private NewCart(string sourceUrl, string customerCookie)
    {
      if (Uri.IsWellFormedUriString(sourceUrl, UriKind.Absolute))
      {
        SourceUrl = sourceUrl;
      }
      else
      {
        SourceUrl = "";
      }

      CustomerCookie = customerCookie;
      CartItems = new List<CartItem>();
    }

    public int CartId { get; private set; }
    public string CartCookie { get; private set; }
    public DateTime Initialized { get; private set; }
    public DateTime Expires { get; private set; }
    public string SourceUrl { get; private set; }
    public int CustomerId { get; private set; }
    public ICollection<CartItem> CartItems { get; }

    //TODO: decide if I should store this property in the database or not
    public string CustomerCookie { get; private set; }

    public static NewCart CreateCartFromProductSelection
      (string sourceUrl, string customerCookie, int productId, int quantity,
        decimal displayedPrice)
    {
      var cart = new NewCart(sourceUrl, customerCookie);
      cart.InitializeCart();
      cart.InsertNewCartItem(productId, quantity, displayedPrice);
      return cart;
    }

    private void InsertNewCartItem(int productId, int quantity, decimal displayedPrice)
    {
      CartItems.Add(CartItem.Create(productId, quantity, displayedPrice, CartCookie));
    }

    private void InitializeCart()
    {
      Initialized = DateTime.Now;
      Expires = Initialized.Add(ShoppingCartSettings.CookieExpiration);
      CartCookie = Guid.NewGuid().ToString();
    }

    public void CustomerFound(int customerId)
    {
      CustomerId = customerId;
    }
  }
}