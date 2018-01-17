namespace GUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdPush : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.aspnetusers", "UserMetaData_Name", c => c.String(unicode: false));
            AddColumn("dbo.aspnetusers", "UserMetaData_Last_Name", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.aspnetusers", "UserMetaData_Last_Name");
            DropColumn("dbo.aspnetusers", "UserMetaData_Name");
        }
    }
}
