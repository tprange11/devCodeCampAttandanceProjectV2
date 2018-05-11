namespace devCodeCampAttendanceV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedhalfdayfieldandreason : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SignIns", "isHalfDay", c => c.Boolean(nullable: false));
            AddColumn("dbo.SignIns", "Reason", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SignIns", "Reason");
            DropColumn("dbo.SignIns", "isHalfDay");
        }
    }
}
