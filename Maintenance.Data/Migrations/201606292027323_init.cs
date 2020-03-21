namespace Maintenance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Maintenance.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        CustomerCookie = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "Maintenance.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                        StateProvince = c.String(),
                        PostalCode = c.String(),
                        AddressType = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("Maintenance.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "Maintenance.ContactDetails",
                c => new
                    {
                        ContactDetailId = c.Int(nullable: false),
                        MobilePhone = c.String(),
                        HomePhone = c.String(),
                        OfficePhone = c.String(),
                        TwitterAlias = c.String(),
                        Facebook = c.String(),
                        LinkedIn = c.String(),
                        Skype = c.String(),
                        Messenger = c.String(),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactDetailId)
                .ForeignKey("Maintenance.Customers", t => t.ContactDetailId)
                .Index(t => t.ContactDetailId);
            
            CreateTable(
                "Maintenance.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        OrderSource = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("Maintenance.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "Maintenance.LineItems",
                c => new
                    {
                        LineItemId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LineItemId)
                .ForeignKey("Maintenance.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("Maintenance.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "Maintenance.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Name = c.String(),
                        ProductionStart = c.DateTime(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        MaxQuantity = c.Int(nullable: false),
                        CurrentPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("Maintenance.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "Maintenance.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Maintenance.Products", "CategoryId", "Maintenance.Categories");
            DropForeignKey("Maintenance.LineItems", "ProductId", "Maintenance.Products");
            DropForeignKey("Maintenance.LineItems", "OrderId", "Maintenance.Orders");
            DropForeignKey("Maintenance.Orders", "CustomerId", "Maintenance.Customers");
            DropForeignKey("Maintenance.ContactDetails", "ContactDetailId", "Maintenance.Customers");
            DropForeignKey("Maintenance.Addresses", "CustomerId", "Maintenance.Customers");
            DropIndex("Maintenance.Products", new[] { "CategoryId" });
            DropIndex("Maintenance.LineItems", new[] { "ProductId" });
            DropIndex("Maintenance.LineItems", new[] { "OrderId" });
            DropIndex("Maintenance.Orders", new[] { "CustomerId" });
            DropIndex("Maintenance.ContactDetails", new[] { "ContactDetailId" });
            DropIndex("Maintenance.Addresses", new[] { "CustomerId" });
            DropTable("Maintenance.Categories");
            DropTable("Maintenance.Products");
            DropTable("Maintenance.LineItems");
            DropTable("Maintenance.Orders");
            DropTable("Maintenance.ContactDetails");
            DropTable("Maintenance.Addresses");
            DropTable("Maintenance.Customers");
        }
    }
}
