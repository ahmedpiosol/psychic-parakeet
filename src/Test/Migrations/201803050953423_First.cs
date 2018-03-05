namespace TestApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        NameAr = c.String(nullable: false, maxLength: 50),
                        NameEn = c.String(nullable: false, maxLength: 50),
                        ManualId = c.Int(),
                        Barcode = c.String(),
                        MadeIn = c.String(),
                        IsSerail = c.Boolean(nullable: false),
                        IsExpire = c.Boolean(nullable: false),
                        Notes = c.String(),
                        CreateDate = c.DateTimeOffset(precision: 7),
                        EditDate = c.DateTimeOffset(precision: 7),
                        CreateBy_Id = c.Guid(),
                        EditBy_Id = c.Guid(),
                        Unit_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreateBy_Id)
                .ForeignKey("dbo.Users", t => t.EditBy_Id)
                .ForeignKey("dbo.Units", t => t.Unit_Id)
                .Index(t => t.CreateBy_Id)
                .Index(t => t.EditBy_Id)
                .Index(t => t.Unit_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                        Group = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Units",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        Notes = c.String(),
                        CreateDate = c.DateTimeOffset(precision: 7),
                        EditDate = c.DateTimeOffset(precision: 7),
                        CreateBy_Id = c.Guid(),
                        EditBy_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreateBy_Id)
                .ForeignKey("dbo.Users", t => t.EditBy_Id)
                .Index(t => t.CreateBy_Id)
                .Index(t => t.EditBy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "Unit_Id", "dbo.Units");
            DropForeignKey("dbo.Units", "EditBy_Id", "dbo.Users");
            DropForeignKey("dbo.Units", "CreateBy_Id", "dbo.Users");
            DropForeignKey("dbo.Items", "EditBy_Id", "dbo.Users");
            DropForeignKey("dbo.Items", "CreateBy_Id", "dbo.Users");
            DropIndex("dbo.Units", new[] { "EditBy_Id" });
            DropIndex("dbo.Units", new[] { "CreateBy_Id" });
            DropIndex("dbo.Users", new[] { "Name" });
            DropIndex("dbo.Items", new[] { "Unit_Id" });
            DropIndex("dbo.Items", new[] { "EditBy_Id" });
            DropIndex("dbo.Items", new[] { "CreateBy_Id" });
            DropTable("dbo.Units");
            DropTable("dbo.Users");
            DropTable("dbo.Items");
        }
    }
}
