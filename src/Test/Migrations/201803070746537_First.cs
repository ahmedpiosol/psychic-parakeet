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
                        Id = c.Int(nullable: false, identity: true),
                        NameAr = c.String(nullable: false, maxLength: 50),
                        NameEn = c.String(maxLength: 50),
                        ManualId = c.Int(),
                        Image = c.Binary(storeType: "image"),
                        UnitId = c.Int(nullable: false),
                        MadeIn = c.String(),
                        IsSerail = c.Boolean(nullable: false),
                        IsExpire = c.Boolean(nullable: false),
                        Notes = c.String(),
                        CreatedById = c.Guid(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        EditedById = c.Guid(),
                        EditDate = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.EditedById)
                .ForeignKey("dbo.Units", t => t.UnitId)
                .Index(t => t.UnitId)
                .Index(t => t.CreatedById)
                .Index(t => t.EditedById);
            
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
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Notes = c.String(),
                        CreatedById = c.Guid(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        EditedById = c.Guid(),
                        EditDate = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .ForeignKey("dbo.Users", t => t.EditedById)
                .Index(t => t.CreatedById)
                .Index(t => t.EditedById);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "UnitId", "dbo.Units");
            DropForeignKey("dbo.Units", "EditedById", "dbo.Users");
            DropForeignKey("dbo.Units", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Items", "EditedById", "dbo.Users");
            DropForeignKey("dbo.Items", "CreatedById", "dbo.Users");
            DropIndex("dbo.Units", new[] { "EditedById" });
            DropIndex("dbo.Units", new[] { "CreatedById" });
            DropIndex("dbo.Users", new[] { "Name" });
            DropIndex("dbo.Items", new[] { "EditedById" });
            DropIndex("dbo.Items", new[] { "CreatedById" });
            DropIndex("dbo.Items", new[] { "UnitId" });
            DropTable("dbo.Units");
            DropTable("dbo.Users");
            DropTable("dbo.Items");
        }
    }
}
