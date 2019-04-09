namespace PrivateSchoolManagerNew.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Marks", "AssignmentID", "dbo.Assignments");
            DropForeignKey("dbo.Marks", "StudentID", "dbo.Students");
            DropIndex("dbo.Marks", new[] { "StudentID" });
            DropIndex("dbo.Marks", new[] { "AssignmentID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Marks", "AssignmentID");
            CreateIndex("dbo.Marks", "StudentID");
            AddForeignKey("dbo.Marks", "StudentID", "dbo.Students", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Marks", "AssignmentID", "dbo.Assignments", "ID", cascadeDelete: true);
        }
    }
}
