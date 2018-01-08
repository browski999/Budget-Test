namespace DotNetAppSqlDb.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddedNewCompanyClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Description = c.String(),
                    Address1 = c.String(),
                    Address2 = c.String(),
                    Postcode = c.String(),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Companies");
        }
    }
}
