
using System.Net;
using System.Web.Mvc;
using MvcSalesApp.Domain;
using MvcSalesApp.Data;

namespace MvcSalesApp.Controllers
{
  public class CustomersController : Controller
  {
     private CustomerData repo = new CustomerData();
 
    // GET: Customers
    public ActionResult Index() {
      return View(repo.GetAllCustomers());
    }

    // GET: Customers/Details/5
    public ActionResult Details(int? id) {
      if (id == null) {
        return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
      }
      Customer customer = repo.FindCustomer(id);
      if (customer == null) {
        return HttpNotFound();
      }
      return View(customer);
    }

    // GET: Customers/Create
    public ActionResult Create() {
      return View();
    }

    // POST: Customers/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "CustomerId,FirstName,LastName,DateOfBirth")] Customer customer) {
      if (ModelState.IsValid) {
        repo.AddCustomer(customer);
        return RedirectToAction("Index");
      }
      return View(customer);
    }

    // GET: Customers/Edit/5
    public ActionResult Edit(int? id) {
      if (id == null) {
        return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
      }
      Customer customer = repo.FindCustomer(id);
      if (customer == null) {
        return HttpNotFound();
      }
      return View(customer);
    }

    // POST: Customers/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "CustomerId,FirstName,LastName,DateOfBirth")] Customer customer) {
      if (ModelState.IsValid) {
        repo.UpdateCustomer(customer);
        return RedirectToAction("Index");
      }
      return View(customer);
    }

    // GET: Customers/Delete/5
    public ActionResult Delete(int? id) {
      if (id == null) {
        return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
      }
      Customer customer = repo.FindCustomer(id);
      if (customer == null) {
        return HttpNotFound();
      }
      return View(customer);
    }

    // POST: Customers/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id) {
      repo.RemoveCustomer(id);

      return RedirectToAction("Index");
    }

  }
}
