namespace Music.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relation1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 100),
                        date = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        SongId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Songs", t => t.SongId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.SongId);
            
            CreateTable(
                "dbo.MessageConclusionTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstUserId = c.Int(nullable: false),
                        SecondUserId = c.Int(nullable: false),
                        FirstUserDate = c.DateTime(nullable: false),
                        SecondUserDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 200),
                        UserId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Messages", t => t.MessageId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.MessageId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PlayLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 1000),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PlayListSongs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SongId = c.Int(nullable: false),
                        PlayListId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PlayLists", t => t.PlayListId, cascadeDelete: true)
                .ForeignKey("dbo.Songs", t => t.SongId, cascadeDelete: true)
                .Index(t => t.SongId)
                .Index(t => t.PlayListId);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocalUrl = c.String(nullable: false, maxLength: 200),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 1000),
                        Type = c.String(nullable: false, maxLength: 50),
                        AuthorName = c.String(nullable: false, maxLength: 50),
                        ReleaseDate = c.DateTime(nullable: false),
                        Album = c.String(nullable: false, maxLength: 50),
                        Duraction = c.Int(nullable: false),
                        NumberOfPlays = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 16),
                        Password = c.String(nullable: false, maxLength: 40),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserMessages", "UserId", "dbo.Users");
            DropForeignKey("dbo.PlayLists", "UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.PlayListSongs", "SongId", "dbo.Songs");
            DropForeignKey("dbo.Comments", "SongId", "dbo.Songs");
            DropForeignKey("dbo.PlayListSongs", "PlayListId", "dbo.PlayLists");
            DropForeignKey("dbo.UserMessages", "MessageId", "dbo.Messages");
            DropIndex("dbo.PlayListSongs", new[] { "PlayListId" });
            DropIndex("dbo.PlayListSongs", new[] { "SongId" });
            DropIndex("dbo.PlayLists", new[] { "UserId" });
            DropIndex("dbo.UserMessages", new[] { "UserId" });
            DropIndex("dbo.UserMessages", new[] { "MessageId" });
            DropIndex("dbo.Comments", new[] { "SongId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Songs");
            DropTable("dbo.PlayListSongs");
            DropTable("dbo.PlayLists");
            DropTable("dbo.UserMessages");
            DropTable("dbo.Messages");
            DropTable("dbo.MessageConclusionTimes");
            DropTable("dbo.Comments");
        }
    }
}
