using System.Web.Mvc;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using MvcSalesApp.Web.CustomerFacing;
using MvcSalesApp.Web.CustomerFacing.DependencyResolution;
using StructureMap;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(StructuremapMvc), "Start")]
[assembly: ApplicationShutdownMethod(typeof(StructuremapMvc), "End")]

namespace MvcSalesApp.Web.CustomerFacing
{
  public static class StructuremapMvc
  {
    #region Public Properties

    public static StructureMapDependencyScope StructureMapDependencyScope { get; set; }

    #endregion Public Properties

    #region Public Methods and Operators

    public static void End() {
      StructureMapDependencyScope.Dispose();
    }

    public static void Start() {
      IContainer container = IoC.Initialize();
      StructureMapDependencyScope = new StructureMapDependencyScope(container);
      DependencyResolver.SetResolver(StructureMapDependencyScope);
      DynamicModuleUtility.RegisterModule(typeof(StructureMapScopeModule));
    }

    #endregion Public Methods and Operators
  }
}