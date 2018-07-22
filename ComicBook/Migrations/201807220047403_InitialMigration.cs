namespace ComicBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Titles",
                c => new
                    {
                        TitleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Artist = c.String(),
                    })
                .PrimaryKey(t => t.TitleId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Titles");
        }
    }
}
