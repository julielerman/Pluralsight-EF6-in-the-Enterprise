using System.Web.Mvc;
using MvcSalesApp.SharedKernel;
using ShoppingCart.Services;

namespace MvcSalesApp.Web.CustomerFacing.Controllers
{
  public class CartController : Controller
  {
    private WebSiteOrderingService _service;

    public CartController(WebSiteOrderingService service) {
      _service = service;
    }

    public ActionResult ItemSelected(int? productId, int quant, decimal unitPrice,
                                     string memberCookie,int cartId) {
      var createdCart =
        _service.ItemSelected(productId.Value, quant, unitPrice,
                              "http://thedatafarm.com", memberCookie,cartId);
      ControllerContext.HttpContext.Response.Cookies.Add(
        CookieUtilities.BuildCartCookie(createdCart.CartCookie, createdCart.CartCookieExpires));
      TempData["CartCount"] =  createdCart.TotalItems;
      TempData["CartId"] = createdCart.CartId;
      return RedirectToAction("../ProductList");
    }
  }
}