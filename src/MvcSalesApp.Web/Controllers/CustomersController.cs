using DisconnectedGenericRepository;
using Maintenance.Domain;
using System.Net;
using System.Web.Mvc;

namespace MvcSalesApp.Controllers
{
  public class CustomersController : Controller
  {
    private GenericRepository<Customer> _repo;

    public CustomersController(GenericRepository<Customer> repo) {
      _repo = repo;
    }
   
    public ActionResult Index() {
      return View(_repo.All());
    }

    public ActionResult Details(int? id) {
      if (id == null) {
        return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
      }
      Customer customer = _repo.FindByKey(id.Value);
      if (customer == null) {
        return HttpNotFound();
      }
      return View(customer);
    }

    public ActionResult Create() {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "CustomerId,FirstName,LastName,DateOfBirth")] Customer customer) {
      if (ModelState.IsValid) {
        _repo.Insert(customer);
        return RedirectToAction("Index");
      }
      return View(customer);
    }

    public ActionResult Edit(int? id) {
      if (id == null) {
        return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
      }
      Customer customer = _repo.FindByKey(id.Value);
      if (customer == null) {
        return HttpNotFound();
      }
      return View(customer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "CustomerId,FirstName,LastName,DateOfBirth")] Customer customer) {
      if (ModelState.IsValid) {
        _repo.Update(customer);
        return RedirectToAction("Index");
      }
      return View(customer);
    }

    public ActionResult Delete(int? id) {
      if (id == null) {
        return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
      }
      Customer customer = _repo.FindByKey(id.Value);
      if (customer == null) {
        return HttpNotFound();
      }
      return View(customer);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id) {
      _repo.Delete(id);

      return RedirectToAction("Index");
    }
  }
}