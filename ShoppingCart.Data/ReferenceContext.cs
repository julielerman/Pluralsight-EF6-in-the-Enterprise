using ShoppingCart.Domain;
using System.Data.Entity;

namespace ShoppingCart.Data
{
  public class ReferenceContext : DbContext
  {
    public ReferenceContext() : base("name=GeekStuffSales") {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
      modelBuilder.HasDefaultSchema("Maintenance");
      modelBuilder.Entity<Product>().ToTable("ProductListing","ShoppingCart");
      base.OnModelCreating(modelBuilder);
    }
  }
}