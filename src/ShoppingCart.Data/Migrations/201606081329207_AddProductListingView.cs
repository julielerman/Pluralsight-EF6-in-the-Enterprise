using System.Data.Entity.Migrations;

namespace ShoppingCart.Data.Migrations
{
  public partial class AddProductListingView : DbMigration
  {
    public override void Up()
    {
      Sql(
        @"IF OBJECT_ID(N'Maintenance.Products', N'U') IS NOT NULL
          BEGIN
           EXEC sp_execute 'CREATE VIEW ShoppingCart.ProductListing
           AS
           SELECT ProductId, Description, P.Name, P.CategoryID,
                   C.Name as Category, MaxQuantity, CurrentPrice
           FROM Maintenance.Products P
           LEFT Join Maintenance.Categories C
           ON P.CategoryId = C.CategoryId
           WHERE p.IsAvailable = 1'
         END");
    }

    public override void Down()
    {
      Sql("DROP VIEW ShoppingCart.ProductListing");
    }
  }
}