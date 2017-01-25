namespace MVC5Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeRequiredFieldsInFood : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Foods", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Foods", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Foods", "Description", c => c.String());
            AlterColumn("dbo.Foods", "Name", c => c.String());
        }
    }
}
