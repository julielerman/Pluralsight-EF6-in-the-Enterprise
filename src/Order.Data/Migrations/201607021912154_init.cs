namespace Order.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Order.SalesOrders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        DueDate = c.DateTime(),
                        OnlineOrder = c.Boolean(nullable: false),
                        PurchaseOrderNumber = c.String(),
                        Comment = c.String(),
                        PromotionId = c.Int(nullable: false),
                        ShippingAddress_Street = c.String(),
                        ShippingAddress_City = c.String(),
                        ShippingAddress_StateProvince = c.String(),
                        ShippingAddress_PostalCode = c.String(),
                        CurrentCustomerStatus = c.Int(nullable: false),
                        CustomerDiscount = c.Double(nullable: false),
                        PromoDiscount = c.Double(nullable: false),
                        SalesOrderNumber = c.String(),
                        CustomerId = c.Int(nullable: false),
                        SubTotal = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Order.LineItems",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        SalesOrderId = c.Guid(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Double(),
                        UnitPriceDiscount = c.Double(),
                        ShipmentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Order.SalesOrders", t => t.SalesOrderId, cascadeDelete: true)
                .Index(t => t.SalesOrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Order.LineItems", "SalesOrderId", "Order.SalesOrders");
            DropIndex("Order.LineItems", new[] { "SalesOrderId" });
            DropTable("Order.LineItems");
            DropTable("Order.SalesOrders");
        }
    }
}
