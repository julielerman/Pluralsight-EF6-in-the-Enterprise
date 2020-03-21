using StructureMap;

namespace MvcSalesApp.Web.CustomerFacing.DependencyResolution
{
  public static class IoC
  {
    public static IContainer Initialize() {
      return new Container(c => c.AddRegistry<DefaultRegistry>());
    }
  }
}
