namespace MVC5Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'16ad23d3-7c21-4963-9825-7ebacab22683', N'email@addr.ess', 0, N'AP7BE7UlHiBtuI9Pto2aka0WjgYyKkN6Rj+s4CCPIzRcM+ledSakOdkTjSntoTXd1w==', N'650fc3ac-2cf9-4e70-ab39-ce474a4ba805', NULL, 0, 0, NULL, 1, 0, N'email@addr.ess')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'73768c1c-2612-4806-89ea-7de3af54e0a2', N'admin@mvc5dessertcafe.com', 0, N'AOzHdJhttl8kivtBL1zfC1CuUptJp6N+LJ+qu/e4FczFD/XT4IfY9loJ3Hl5EqFGqA==', N'75582c4f-b2ad-46a9-ae35-faab9dc23c4b', NULL, 0, 0, NULL, 1, 0, N'admin@mvc5dessertcafe.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd39335f4-5e77-49c4-90d9-e88277a60f9d', N'CanManageFood')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'73768c1c-2612-4806-89ea-7de3af54e0a2', N'd39335f4-5e77-49c4-90d9-e88277a60f9d')

");
        }
        
        public override void Down()
        {
        }
    }
}
