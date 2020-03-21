using System.Net;
using System.Web.Mvc;
using Maintenance.Data;

namespace MvcSalesApp.Controllers
{
  public class CustomersWithOrdersController : Controller
  {
      private CustomerWithOrdersData _repo;
    public CustomersWithOrdersController(CustomerWithOrdersData repo) {
      _repo = repo;
    }

    public ActionResult Index() {
      return View(_repo.GetAllCustomers());
    }

      public ActionResult Details(int? id) {
      if (id == null) {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var customer = _repo.FindCustomer(id);
      if (customer == null) {
        return HttpNotFound();
      }
      return View(customer);
    }
  }
}
