using System.Collections.Generic;

namespace MvcSalesApp.Web.CustomerFacing.ViewModels
{
  public class ShoppingViewModel
  {
    public int CartId { get;  set; }
    public string CartCookie { get;  set; }
    public int CartCount { get; set; }
    public List<ProductLineItemViewModel> Products { get; set; }
  }
}
