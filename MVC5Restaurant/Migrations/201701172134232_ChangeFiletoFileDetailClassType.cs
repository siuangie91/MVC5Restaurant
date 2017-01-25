namespace MVC5Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFiletoFileDetailClassType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        Extension = c.String(),
                        Food_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Foods", t => t.Food_Id)
                .Index(t => t.Food_Id);
            
            DropColumn("dbo.Foods", "File");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Foods", "File", c => c.String());
            DropForeignKey("dbo.FileDetails", "Food_Id", "dbo.Foods");
            DropIndex("dbo.FileDetails", new[] { "Food_Id" });
            DropTable("dbo.FileDetails");
        }
    }
}
