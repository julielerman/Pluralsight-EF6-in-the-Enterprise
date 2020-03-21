using Order.Read.Domain;
using System.Data.Entity;

namespace Order.Read.Data
{
    public class OrderReadContext: DbContext
    {
      public OrderReadContext() : base("name=GeekStuffSales") {
        
      }
      public DbSet<SalesOrder> Orders { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
      modelBuilder.HasDefaultSchema("Order");
   }
  }
  public class OrderSystemContextConfig : DbConfiguration
  {
    public OrderSystemContextConfig() {
      SetDatabaseInitializer(new NullDatabaseInitializer<OrderReadContext>());
    }

  }
}
