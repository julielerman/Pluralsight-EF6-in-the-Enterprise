using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSalesApp.Web.CustomerFacing.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index() {
      ViewBag.Title = "Home Page";

      return View();
    }
  }
}
