using MvcSalesApp.SharedKernel;

namespace Order.Domain.DTOs
{
  public class CartItem
  {
    public static CartItem Create(int productId, decimal price, int quantity)
    {
      return new CartItem(productId, price, quantity);
    }

    public CartItem(int productId, decimal price, int quantity)
    {
      ProductId = productId;
      Price = price;
      Quantity = quantity;
    }
    public int ProductId { get; private set; }
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    }
  }
