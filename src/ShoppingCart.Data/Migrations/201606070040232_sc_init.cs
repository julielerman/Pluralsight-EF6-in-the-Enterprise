namespace ShoppingCart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sc_init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "ShoppingCart.CartItems",
                c => new
                    {
                        CartItemId = c.Int(nullable: false, identity: true),
                        CartCookie = c.String(),
                        CartId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        SelectedDateTime = c.DateTime(nullable: false),
                        CurrentPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartItemId)
                .ForeignKey("ShoppingCart.NewCarts", t => t.CartId, cascadeDelete: true)
                .Index(t => t.CartId);
            
            CreateTable(
                "ShoppingCart.NewCarts",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        CartCookie = c.String(),
                        Initialized = c.DateTime(nullable: false),
                        Expires = c.DateTime(nullable: false),
                        SourceUrl = c.String(),
                        CustomerId = c.Int(nullable: false),
                        CustomerCookie = c.String(),
                    })
                .PrimaryKey(t => t.CartId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("ShoppingCart.CartItems", "CartId", "ShoppingCart.NewCarts");
            DropIndex("ShoppingCart.CartItems", new[] { "CartId" });
            DropTable("ShoppingCart.NewCarts");
            DropTable("ShoppingCart.CartItems");
        }
    }
}
