using System;
using MvcSalesApp.SharedKernel.Enums;

namespace ShoppingCart.Domain
{
  public interface ICartItem
  {
    string CartCookie { get; }
    int CartId { get; set; }
    int CartItemId { get; }
    decimal CurrentPrice { get; }
    int ProductId { get; }
    int Quantity { get; }
    DateTime SelectedDateTime { get; }
    ObjectState State { get; }

    void UpdateQuantity(int newQuantity);
  }
}