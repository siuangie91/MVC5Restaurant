namespace MVC5Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevertToStringTypeFilePropForTesting : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FileDetails", "Food_Id", "dbo.Foods");
            DropIndex("dbo.FileDetails", new[] { "Food_Id" });
            AddColumn("dbo.Foods", "File", c => c.String());
            DropColumn("dbo.FileDetails", "Food_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FileDetails", "Food_Id", c => c.Int());
            DropColumn("dbo.Foods", "File");
            CreateIndex("dbo.FileDetails", "Food_Id");
            AddForeignKey("dbo.FileDetails", "Food_Id", "dbo.Foods", "Id");
        }
    }
}
