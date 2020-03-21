using DisconnectedGenericRepository;
using System.Net;
using System.Web.Mvc;
using Maintenance.Domain;

namespace MvcSalesApp.Controllers
{
  public class ProductsController : Controller
  {
    private GenericRepository<Product> _repo;

    public ProductsController(GenericRepository<Product> repo) {
      _repo = repo;
    }

    // GET: Products
    public ActionResult Index() {
      return View(_repo.All());
    }

    // GET: Products/Details/5
    public ActionResult Details(int? id) {
      if (id == null) {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Product product = _repo.FindByKey(id.Value);
      if (product == null) {
        return HttpNotFound();
      }
      return View(product);
    }

    // GET: Products/Create
    public ActionResult Create() {
      return View();
    }

    // POST: Products/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "ProductId,Description,Name,ProductionStart")] Product product) {
      if (ModelState.IsValid) {
        _repo.Insert(product);
        return RedirectToAction("Index");
      }

      return View(product);
    }

    // GET: Products/Edit/5
    public ActionResult Edit(int? id) {
      if (id == null) {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Product product = _repo.FindByKey(id.Value);
      if (product == null) {
        return HttpNotFound();
      }
      return View(product);
    }

    // POST: Products/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    //public ActionResult Edit([Bind(Include = "ProductId,Description,Name,ProductionStart")] Product product) {
       public ActionResult Edit(Product product) {

      if (ModelState.IsValid) {
        _repo.Update(product);
        return RedirectToAction("Index");
      }
      return View(product);
    }

    // GET: Products/Delete/5
    public ActionResult Delete(int? id) {
      if (id == null) {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Product product = _repo.FindByKey(id.Value);
      if (product == null) {
        return HttpNotFound();
      }
      return View(product);
    }

    // POST: Products/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id) {
      _repo.Delete(id);
      return RedirectToAction("Index");
    }
  }
}