namespace TestApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNavigation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "User_Id", c => c.Guid());
            CreateIndex("dbo.Items", "User_Id");
            AddForeignKey("dbo.Items", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "User_Id", "dbo.Users");
            DropIndex("dbo.Items", new[] { "User_Id" });
            DropColumn("dbo.Items", "User_Id");
        }
    }
}
