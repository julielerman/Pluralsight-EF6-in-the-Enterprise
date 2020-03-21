using MvcSalesApp.App_Start;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(StructuremapMvc), "Start")]
[assembly: ApplicationShutdownMethod(typeof(StructuremapMvc), "End")]

namespace MvcSalesApp.App_Start
{
  using DependencyResolution;
  using Microsoft.Web.Infrastructure.DynamicModuleHelper;
  using StructureMap;
  using System.Web.Mvc;

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