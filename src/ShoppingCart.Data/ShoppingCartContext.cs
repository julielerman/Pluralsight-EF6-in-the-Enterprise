using MvcSalesApp.SharedKernel.Interfaces;
using ShoppingCart.Domain;
using System.Data.Entity;

namespace ShoppingCart.Data
{
  public class ShoppingCartContext : DbContext
  {
    public ShoppingCartContext() : base("name=GeekStuffSales") {
    }

    public DbSet<NewCart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
      modelBuilder.HasDefaultSchema("ShoppingCart");
      modelBuilder.Entity<NewCart>().HasKey(c => c.CartId);
      modelBuilder.Ignore<RevisitedCart>();
      modelBuilder.Types<IStateObject>().Configure(c => c.Ignore(p => p.State));
      base.OnModelCreating(modelBuilder);
    }
  }

  //public class ShoppingCartContextConfig : DbConfiguration
  //{
  //  public ShoppingCartContextConfig() {
  //    this.SetDatabaseInitializer(new NullDatabaseInitializer<ShoppingCartContext>());
  //  }
  //}
}