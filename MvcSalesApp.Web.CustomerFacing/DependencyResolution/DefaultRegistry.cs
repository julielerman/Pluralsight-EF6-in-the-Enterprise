using StructureMap;
using StructureMap.Graph;


namespace MvcSalesApp.Web.CustomerFacing.DependencyResolution
{
  // using DisconnectedGenericRepository;

  public class DefaultRegistry : Registry
  {
    #region Constructors and Destructors

    public DefaultRegistry() {
      Scan(
          scan =>
          {
            scan.TheCallingAssembly();
            scan.WithDefaultConventions();
            scan.With(new ControllerConvention());
          });
      //remember that Transient is the default. Left it here as a reminder
   //   For<DbContext>().Use<ShoppingCartContext>().Transient();


      //Alternate
      //For(typeof(GenericRepository<>))
      //  .Use(typeof(GenericRepository<>))
      //  .Ctor<DbContext>().Is(new OrderSystemContext());
    }

    private class ShoppingCartContext
    {
    }

    #endregion Constructors and Destructors
  }
}