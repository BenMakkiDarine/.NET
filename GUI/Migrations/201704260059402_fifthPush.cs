
namespace GUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifthPush : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.aspnetusers", "ImagePath", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.aspnetusers", "ImagePath");
        }
    }
}
