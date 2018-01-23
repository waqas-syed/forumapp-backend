namespace ForumApp.Forum.Infrastructure.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.comment",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AuthorEmail = c.String(nullable: false, maxLength: 100),
                        Text = c.String(nullable: false, maxLength: 2000),
                        PostId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.post", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.post",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 4000),
                        Category = c.String(),
                        PosterEmail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.comment", "PostId", "dbo.post");
            DropIndex("dbo.comment", new[] { "PostId" });
            DropTable("dbo.post");
            DropTable("dbo.comment");
            DropTable("dbo.Categories");
        }
    }
}
