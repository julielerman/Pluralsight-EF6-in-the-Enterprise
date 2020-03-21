


namespace MvcSalesApp.Web.CustomerFacing.DependencyResolution
{

  using StructureMap.Web.Pipeline;
  using MvcSalesApp.Web.CustomerFacing;
  using System.Web;

 public class StructureMapScopeModule : IHttpModule
  {
    #region Public Methods and Operators

    public void Dispose() {
    }

    public void Init(HttpApplication context) {
      context.BeginRequest += (sender, e) => StructuremapMvc.StructureMapDependencyScope.CreateNestedContainer();
      context.EndRequest += (sender, e) =>
      {
        HttpContextLifecycle.DisposeAndClearAll();
        StructuremapMvc.StructureMapDependencyScope.DisposeNestedContainer();
      };
    }

    #endregion Public Methods and Operators
  }
}