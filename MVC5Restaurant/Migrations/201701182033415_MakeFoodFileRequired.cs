namespace MVC5Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeFoodFileRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Foods", "File", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Foods", "File", c => c.String());
        }
    }
}
