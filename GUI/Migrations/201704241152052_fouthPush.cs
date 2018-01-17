namespace GUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fouthPush : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.aspnetusers", "Name", c => c.String(unicode: false));
            AddColumn("dbo.aspnetusers", "Last_Name", c => c.String(unicode: false));
            DropColumn("dbo.aspnetusers", "UserMetaData_Name");
            DropColumn("dbo.aspnetusers", "UserMetaData_Last_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.aspnetusers", "UserMetaData_Last_Name", c => c.String(unicode: false));
            AddColumn("dbo.aspnetusers", "UserMetaData_Name", c => c.String(unicode: false));
            DropColumn("dbo.aspnetusers", "Last_Name");
            DropColumn("dbo.aspnetusers", "Name");
        }
    }
}
