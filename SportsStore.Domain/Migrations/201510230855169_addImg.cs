namespace SportsStore.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "ImageData", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "ImageData");
        }
    }
}
