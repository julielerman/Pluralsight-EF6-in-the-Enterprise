namespace MvcSalesApp.Web.CustomerFacing.ViewModels
{
  public class ProductLineItemViewModel
  {
    public int ProductId { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public int Quantity { get; set; }
    public int MaxQuantity { get; set; }
    public decimal CurrentUnitPrice { get; set; }
  }
}