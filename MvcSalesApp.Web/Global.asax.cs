using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MvcSalesApp.SharedKernel.Settings;


namespace MvcSalesApp
{
  public class MvcApplication : System.Web.HttpApplication
  {
    protected void Application_Start() {
      AreaRegistration.RegisterAllAreas();
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
      //Hard coded because it's a demo
      ShoppingCartSettings.ShouldBeProtectedCookieExpirationSetter(TimeSpan.FromDays(7));
    }
  }
}
