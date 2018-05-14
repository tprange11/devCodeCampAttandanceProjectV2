namespace devCodeCampAttendanceV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatefeild : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SignIns", "HalfDay", c => c.Boolean(nullable: false));
            DropColumn("dbo.SignIns", "isHalfDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SignIns", "isHalfDay", c => c.Boolean(nullable: false));
            DropColumn("dbo.SignIns", "HalfDay");
        }
    }
}
