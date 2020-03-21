using System;
using System.Collections.Generic;

namespace ShoppingCart.Domain
{
  public interface INewCart
  {
    string CartCookie { get; }
    int CartId { get; }
    ICollection<CartItem> CartItems { get; }
    string CustomerCookie { get; }
    int CustomerId { get; }
    DateTime Expires { get; }
    DateTime Initialized { get; }
    string SourceUrl { get; }

    void CustomerFound(int customerId);
  }
}