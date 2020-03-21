namespace Maintenance.Domain
{
  public class LineItem
  {
    public int LineItemId { get; set; }
    public int Quantity { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    

    public Order Order { get; set; }
    public Product Product { get; set; }
  }
} 