using Order.Domain;
using System.Data.Entity;

namespace Order.Data
{
    public class OrderContext: DbContext
    {
      public OrderContext() : base("name=GeekStuffSales") {
        
      }
      public DbSet<SalesOrder> Orders { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
      modelBuilder.HasDefaultSchema("Order");
     modelBuilder.Ignore<Domain.DTOs.Customer>();
      modelBuilder.Ignore<Domain.DTOs.CartItem>();
    }
  }
  public class OrderSystemContextConfig : DbConfiguration
  {
    public OrderSystemContextConfig() {
      SetDatabaseInitializer(new NullDatabaseInitializer<OrderContext>());
    }

  }
}
