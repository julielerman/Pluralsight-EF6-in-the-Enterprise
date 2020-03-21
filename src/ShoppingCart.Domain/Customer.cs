namespace ShoppingCart.Domain
{
  public class Customer
  {
    public virtual int CustomerId { get; private set; }
    public virtual string CustomerCookie { get; private set; }
  }
}