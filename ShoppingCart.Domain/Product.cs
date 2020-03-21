namespace ShoppingCart.Domain
{
  public class Product
  {
    public int ProductId { get; private set; }
    public string Description { get; private set; }
    public string Name { get; private set; }
    public int CategoryId { get; private set; }
    public string Category { get; private set; }
    public int MaxQuantity { get; private set; }
    public decimal CurrentPrice { get; private set; }
  }
}