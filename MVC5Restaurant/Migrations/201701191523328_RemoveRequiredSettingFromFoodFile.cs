namespace MVC5Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredSettingFromFoodFile : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Foods", "File", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Foods", "File", c => c.String(nullable: false));
        }
    }
}
