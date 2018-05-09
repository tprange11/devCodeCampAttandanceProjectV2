namespace devCodeCampAttendanceV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserIDToStudentModelForLater : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "UserID");
        }
    }
}
