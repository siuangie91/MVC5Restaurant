namespace MVC5Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveFileDetailClass : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.FileDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FileDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        Extension = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
