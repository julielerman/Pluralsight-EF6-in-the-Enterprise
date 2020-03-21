using System.Data.Entity;
using Order.Read.Domain;

namespace Order.Write.Data
{
  public class OrderWriteContext : DbContext
  {
    public OrderWriteContext() : base("name=GeekStuffSales")
    {
    }

    public DbSet<SalesOrder> Orders { get; set; }
    public DbSet<LineItem> LineItems { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.HasDefaultSchema("Order");
      modelBuilder.Entity<SalesOrder>().Ignore(s => s.LineItems);
    }
  }

  public class OrderSystemContextConfig : DbConfiguration
  {
    public OrderSystemContextConfig()
    {
      SetDatabaseInitializer(new NullDatabaseInitializer<OrderWriteContext>());
    }
  }
}