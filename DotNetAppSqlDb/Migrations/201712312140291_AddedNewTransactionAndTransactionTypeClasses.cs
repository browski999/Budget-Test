namespace DotNetAppSqlDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNewTransactionAndTransactionTypeClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransactionDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        AuthCode = c.String(),
                        Company_Id = c.Int(),
                        TransactionType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .ForeignKey("dbo.TransactionTypes", t => t.TransactionType_Id)
                .Index(t => t.Company_Id)
                .Index(t => t.TransactionType_Id);
            
            CreateTable(
                "dbo.TransactionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "TransactionType_Id", "dbo.TransactionTypes");
            DropForeignKey("dbo.Transactions", "Company_Id", "dbo.Companies");
            DropIndex("dbo.Transactions", new[] { "TransactionType_Id" });
            DropIndex("dbo.Transactions", new[] { "Company_Id" });
            DropTable("dbo.TransactionTypes");
            DropTable("dbo.Transactions");
        }
    }
}
