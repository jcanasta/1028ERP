namespace ERP.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSO : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SalesOrders", "CustomerID", c => c.Int(nullable: false));
            CreateIndex("dbo.SalesOrders", "CustomerID");
            AddForeignKey("dbo.SalesOrders", "CustomerID", "dbo.Customers", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesOrders", "CustomerID", "dbo.Customers");
            DropIndex("dbo.SalesOrders", new[] { "CustomerID" });
            AlterColumn("dbo.SalesOrders", "CustomerID", c => c.String());
        }
    }
}
