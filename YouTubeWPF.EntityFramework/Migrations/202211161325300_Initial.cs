namespace YouTubeWPF.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.YouTubeViewerDtoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(),
                        IsSubscribed = c.Boolean(nullable: false),
                        IsMember = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.YouTubeViewerDtoes");
        }
    }
}
